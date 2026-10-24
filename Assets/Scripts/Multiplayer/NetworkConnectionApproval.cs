using System.Text;
using Unity.Netcode;
using UnityEngine;

namespace AyutthayaSimulator.Multiplayer
{
    public sealed class NetworkConnectionApproval : MonoBehaviour
    {
        [SerializeField] private NetworkManager manager;
        [SerializeField] private int maxPlayers = 2;
        [SerializeField] private NetworkSpawnPoint spawnPoint;
        private void Awake() { if (manager == null) manager = NetworkManager.Singleton; if (manager != null) { manager.NetworkConfig.ConnectionApproval = true; manager.ConnectionApprovalCallback += Approve; manager.OnClientConnectedCallback += Spawn; } }
        private void OnDestroy() { if (manager != null) manager.ConnectionApprovalCallback -= Approve; }
        private void Approve(NetworkManager.ConnectionApprovalRequest request, NetworkManager.ConnectionApprovalResponse response) { response.Approved = manager.ConnectedClientsList.Count < maxPlayers; response.CreatePlayerObject = false; response.Pending = false; response.Reason = response.Approved ? string.Empty : "Lobby is full"; }
        private void Spawn(ulong clientId) { if (manager.IsServer) spawnPoint?.SpawnFor(clientId); }
    }
}
