using NUnit.Framework;
using UnityEngine;
using AyutthayaSimulator.Multiplayer;

public sealed class MultiplayerTests
{
    [Test] public void OfflineMode_IsDefault() { GameObject go = new GameObject("Session"); NetworkSessionManager session = go.AddComponent<NetworkSessionManager>(); Assert.AreEqual(NetworkMode.Offline, session.Mode); Object.DestroyImmediate(go); }
    [Test] public void SpawnPoint_UsesFallbackTransformWithoutConfiguredPoints() { GameObject go = new GameObject("Spawn"); NetworkSpawnPoint point = go.AddComponent<NetworkSpawnPoint>(); Assert.IsNotNull(point.transform); Object.DestroyImmediate(go); }
}
