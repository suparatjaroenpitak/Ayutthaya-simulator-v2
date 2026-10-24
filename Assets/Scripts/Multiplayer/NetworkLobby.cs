using Unity.Netcode;
using UnityEngine;

namespace AyutthayaSimulator.Multiplayer
{
    public sealed class NetworkLobby : NetworkBehaviour
    {
        public NetworkVariable<int> PlayerCount = new NetworkVariable<int>(0, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
        public override void OnNetworkSpawn() { if (IsServer) { PlayerCount.Value = NetworkManager.Singleton.ConnectedClientsList.Count; NetworkManager.Singleton.OnClientConnectedCallback += Refresh; NetworkManager.Singleton.OnClientDisconnectCallback += Refresh; } }
        public override void OnNetworkDespawn() { if (IsServer && NetworkManager.Singleton != null) { NetworkManager.Singleton.OnClientConnectedCallback -= Refresh; NetworkManager.Singleton.OnClientDisconnectCallback -= Refresh; } }
        private void Refresh(ulong _) { if (IsServer) PlayerCount.Value = NetworkManager.Singleton.ConnectedClientsList.Count; }
    }
}
