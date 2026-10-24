using Unity.Netcode;
using UnityEngine;

namespace AyutthayaSimulator.Multiplayer
{
    public interface INetworkInteractionValidator { bool Validate(ulong clientId, string interactionId); }
    public sealed class NetworkInteractable : NetworkBehaviour
    {
        [SerializeField] private string interactionId;
        [SerializeField] private float maxDistance = 3f;
        [SerializeField] private MonoBehaviour validatorComponent;
        public event System.Action<ulong> ServerInteraction;
        public void RequestInteraction() { if (IsOwner) RequestInteractionServerRpc(); }
        [ServerRpc(RequireOwnership = false)] private void RequestInteractionServerRpc(ServerRpcParams rpcParams = default)
        {
            if (NetworkManager.Singleton.ConnectedClients.TryGetValue(rpcParams.Receive.SenderClientId, out NetworkClient client) && client.PlayerObject != null && Vector3.Distance(client.PlayerObject.transform.position, transform.position) <= maxDistance && (validatorComponent == null || validatorComponent is INetworkInteractionValidator v && v.Validate(rpcParams.Receive.SenderClientId, interactionId))) ServerInteraction?.Invoke(rpcParams.Receive.SenderClientId);
        }
    }
}
