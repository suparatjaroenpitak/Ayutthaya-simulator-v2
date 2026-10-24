using UnityEngine;

namespace AyutthayaSimulator.Narrative
{
    public sealed class QuestUIModel : MonoBehaviour
    {
        [SerializeField] private QuestService quests;
        public event System.Action<QuestDefinition, QuestProgress> Changed;
        private void OnEnable() { if (quests != null) quests.ProgressChanged += OnChanged; }
        private void OnDisable() { if (quests != null) quests.ProgressChanged -= OnChanged; }
        private void OnChanged(QuestDefinition quest, QuestProgress progress) => Changed?.Invoke(quest, progress);
    }
}
