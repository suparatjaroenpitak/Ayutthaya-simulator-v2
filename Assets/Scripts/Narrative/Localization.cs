using System;
using UnityEngine;

namespace AyutthayaSimulator.Narrative
{
    public enum DialogueLanguage { Thai, English }
    [Serializable] public struct LocalizedText { [TextArea] public string thai; [TextArea] public string english; public string Get(DialogueLanguage language) => language == DialogueLanguage.Thai ? thai : english; }
    [CreateAssetMenu(menuName = "Ayutthaya/Narrative/Dialogue Line", fileName = "DialogueLine")]
    public sealed class DialogueLine : ScriptableObject
    {
        public string speakerId;
        public LocalizedText text;
        public string[] nextNodeIds = Array.Empty<string>();
        public string requiredFlag;
        public string setFlag;
        public int relationshipDelta;
    }
    public sealed class DialogueRunner : MonoBehaviour
    {
        [SerializeField] private DialogueLanguage language = DialogueLanguage.Thai;
        public event Action<DialogueLine, string> LineShown;
        public void Show(DialogueLine line) { if (line != null) LineShown?.Invoke(line, line.text.Get(language)); }
        public void SetLanguage(DialogueLanguage value) => language = value;
    }

    public sealed class DialogueSession : MonoBehaviour
    {
        [SerializeField] private DialogueLine[] nodes = Array.Empty<DialogueLine>();
        [SerializeField] private StoryStateService story;
        [SerializeField] private NPC.NPCRelationshipStore relationships;
        public DialogueLine Current { get; private set; }
        public bool Begin(string nodeId) { Current = Find(nodeId); return Current != null && (string.IsNullOrWhiteSpace(Current.requiredFlag) || story != null && story.State.HasFlag(Current.requiredFlag)); }
        public bool Choose(int branchIndex, string npcId)
        {
            if (Current == null || branchIndex < 0 || branchIndex >= Current.nextNodeIds.Length) return false;
            if (!string.IsNullOrWhiteSpace(Current.setFlag)) story?.SetFlag(Current.setFlag);
            if (relationships != null && Current.relationshipDelta != 0) relationships.Adjust(npcId, Current.relationshipDelta);
            Current = Find(Current.nextNodeIds[branchIndex]); return Current != null;
        }
        private DialogueLine Find(string id) { for (int i = 0; i < nodes.Length; i++) if (nodes[i] != null && nodes[i].name == id) return nodes[i]; return null; }
    }
}
