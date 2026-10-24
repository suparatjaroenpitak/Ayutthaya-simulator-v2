using System;
using UnityEngine;

namespace AyutthayaSimulator.Narrative
{
    public enum QuestType { Main, Side }
    public enum ObjectiveType { Talk, Reach, Collect, Farm, Sell, Repair, Rest }
    [Serializable] public struct QuestPrerequisite { public string requiredFlag; public string requiredQuestId; public int minimumRelationship; public string npcId; }
    [Serializable] public struct QuestObjective { public string objectiveId; public ObjectiveType type; public LocalizedText description; public int requiredAmount; public string targetId; }
    [Serializable] public struct QuestReward { public int experience; public long moneySatang; public string flagToSet; public int relationshipDelta; public string npcId; }
    [CreateAssetMenu(menuName = "Ayutthaya/Narrative/Quest Definition", fileName = "QuestDefinition")]
    public sealed class QuestDefinition : ScriptableObject
    {
        public string questId;
        public QuestType type;
        public LocalizedText title;
        public LocalizedText summary;
        public QuestPrerequisite[] prerequisites = Array.Empty<QuestPrerequisite>();
        public QuestObjective[] objectives = Array.Empty<QuestObjective>();
        public QuestReward[] rewards = Array.Empty<QuestReward>();
        public bool replaySafe = true;
    }
}
