using UnityEngine;

namespace AyutthayaSimulator.NPC
{
    public interface IConversationParticipant
    {
        string ConversationId { get; }
        void OnConversationStarted(GameObject initiator);
        void OnConversationEnded(GameObject initiator);
    }

    public sealed class NPCConversation : MonoBehaviour, IConversationParticipant
    {
        [SerializeField] private string conversationId = "generic_civilian";
        public string ConversationId => conversationId;
        public void OnConversationStarted(GameObject initiator) { }
        public void OnConversationEnded(GameObject initiator) { }
        public bool TryStart(GameObject initiator, float distance)
        {
            if (initiator == null || distance > 2f) return false;
            OnConversationStarted(initiator);
            return true;
        }
    }
}
