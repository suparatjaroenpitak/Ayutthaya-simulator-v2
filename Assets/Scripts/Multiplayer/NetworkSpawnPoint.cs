using Unity.Netcode;
using UnityEngine;

namespace AyutthayaSimulator.Multiplayer
{
    public sealed class NetworkSpawnPoint : MonoBehaviour
    {
        [SerializeField] private NetworkObject playerPrefab;
        [SerializeField] private Transform[] spawnPoints = new Transform[0];
        private int cursor;
        public void SpawnFor(ulong clientId)
        {
            if (!NetworkManager.Singleton.IsServer || playerPrefab == null) return;
            Transform point = spawnPoints.Length == 0 ? transform : spawnPoints[cursor++ % spawnPoints.Length];
            NetworkObject player = Instantiate(playerPrefab, point.position, point.rotation); player.SpawnAsPlayerObject(clientId, true);
        }
    }
}
