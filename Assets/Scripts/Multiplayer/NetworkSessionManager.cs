using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

namespace AyutthayaSimulator.Multiplayer
{
    public sealed class NetworkSessionManager : MonoBehaviour
    {
        [SerializeField] private NetworkManager manager;
        [SerializeField] private string address = "127.0.0.1";
        [SerializeField] private ushort port = 7777;
        public NetworkMode Mode { get; private set; } = NetworkMode.Offline;
        public event System.Action<string> ConnectionStatusChanged;
        private void Awake() { if (manager == null) manager = NetworkManager.Singleton; if (manager != null) { manager.OnClientConnectedCallback += OnConnected; manager.OnClientDisconnectCallback += OnDisconnected; } }
        private void OnDestroy() { if (manager != null) { manager.OnClientConnectedCallback -= OnConnected; manager.OnClientDisconnectCallback -= OnDisconnected; } }
        public bool StartHost() { ConfigureTransport(); Mode = NetworkMode.Host; return manager != null && manager.StartHost(); }
        public bool StartClient() { ConfigureTransport(); Mode = NetworkMode.Client; return manager != null && manager.StartClient(); }
        public bool StartDedicatedServer() { ConfigureTransport(); Mode = NetworkMode.DedicatedServer; return manager != null && manager.StartServer(); }
        public void ShutdownGracefully() { if (manager != null && manager.IsListening) manager.Shutdown(); Mode = NetworkMode.Offline; ConnectionStatusChanged?.Invoke("offline"); }
        private void ConfigureTransport() { UnityTransport transport = manager == null ? null : manager.GetComponent<UnityTransport>(); if (transport != null) transport.SetConnectionData(address, port); }
        private void OnConnected(ulong clientId) => ConnectionStatusChanged?.Invoke("connected:" + clientId);
        private void OnDisconnected(ulong clientId) => ConnectionStatusChanged?.Invoke("disconnected:" + clientId);
    }
}
