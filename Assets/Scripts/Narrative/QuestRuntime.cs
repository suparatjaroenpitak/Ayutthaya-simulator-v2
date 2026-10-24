using System;
using System.Collections.Generic;
using UnityEngine;
using AyutthayaSimulator.Economy;
using AyutthayaSimulator.NPC;

namespace AyutthayaSimulator.Narrative
{
    [Serializable] public sealed class QuestProgress { public string questId; public int[] amounts = Array.Empty<int>(); public bool completed; }
    public sealed class QuestService : MonoBehaviour
    {
        [SerializeField] private QuestDefinition[] definitions = Array.Empty<QuestDefinition>();
        [SerializeField] private StoryStateService story;
        [SerializeField] private Wallet wallet;
        [SerializeField] private NPCRelationshipStore relationships;
        [SerializeField] private MonoBehaviour authorityComponent;
        private readonly Dictionary<string, QuestProgress> active = new Dictionary<string, QuestProgress>();
        private IQuestAuthority authority;
        private void Awake() => authority = authorityComponent as IQuestAuthority;
        public event Action<QuestDefinition, QuestProgress> ProgressChanged;
        public QuestDefinition Find(string id) { for (int i = 0; i < definitions.Length; i++) if (definitions[i] != null && definitions[i].questId == id) return definitions[i]; return null; }
        public bool CanStart(string id)
        {
            QuestDefinition quest = Find(id); if (quest == null || story == null || story.State.HasCompleted(id)) return false;
            for (int i = 0; i < quest.prerequisites.Length; i++) { QuestPrerequisite p = quest.prerequisites[i]; if (!string.IsNullOrWhiteSpace(p.requiredFlag) && !story.State.HasFlag(p.requiredFlag)) return false; if (!string.IsNullOrWhiteSpace(p.requiredQuestId) && !story.State.HasCompleted(p.requiredQuestId)) return false; if (p.minimumRelationship != 0 && (relationships == null || relationships.Get(p.npcId) < p.minimumRelationship)) return false; }
            return true;
        }
        public bool Start(string id) { if (!CanStart(id) || active.ContainsKey(id)) return false; QuestDefinition quest = Find(id); active[id] = new QuestProgress { questId = id, amounts = new int[quest.objectives.Length] }; return true; }
        public bool Advance(string id, string objectiveId, int amount = 1)
        {
            if (!active.TryGetValue(id, out QuestProgress progress) || progress.completed) return false; QuestDefinition quest = Find(id); int index = -1; for (int i = 0; i < quest.objectives.Length; i++) if (quest.objectives[i].objectiveId == objectiveId) { index = i; break; } if (index < 0) return false;
            progress.amounts[index] = Mathf.Min(quest.objectives[index].requiredAmount, progress.amounts[index] + Mathf.Max(0, amount)); ProgressChanged?.Invoke(quest, progress); return true;
        }
        public bool Complete(string id, string actorId)
        {
            if (authority != null && !authority.CanComplete(actorId, id)) return false;
            if (!active.TryGetValue(id, out QuestProgress progress) || progress.completed) return false; QuestDefinition quest = Find(id); for (int i = 0; i < quest.objectives.Length; i++) if (progress.amounts[i] < quest.objectives[i].requiredAmount) return false;
            if (story == null || !story.MarkCompleted(id)) return false;
            progress.completed = true; active.Remove(id);
            for (int i = 0; i < quest.rewards.Length; i++) { QuestReward reward = quest.rewards[i]; if (wallet != null && reward.moneySatang > 0) wallet.TryCredit(reward.moneySatang); if (relationships != null && !string.IsNullOrWhiteSpace(reward.npcId)) relationships.Adjust(reward.npcId, reward.relationshipDelta); if (story != null) story.SetFlag(reward.flagToSet); }
            return true;
        }
        public bool IsActive(string id) => active.ContainsKey(id);
    }

    public interface IQuestAuthority { bool CanComplete(string actorId, string questId); }
    public sealed class ServerQuestAuthority : MonoBehaviour, IQuestAuthority
    {
        [SerializeField] private bool serverMode = true;
        public bool CanComplete(string actorId, string questId) => serverMode && !string.IsNullOrWhiteSpace(actorId) && !string.IsNullOrWhiteSpace(questId);
    }
}
