using System;
using UnityEngine;

namespace AyutthayaSimulator.Persistence
{
    [Serializable] public sealed class PersistentPlayerData
    {
        public string playerId; public int schemaVersion = 1; public long walletSatang; public long bankSatang; public string[] inventoryIds = Array.Empty<string>(); public int[] inventoryQuantities = Array.Empty<int>(); public string[] propertyIds = Array.Empty<string>(); public string[] questFlags = Array.Empty<string>(); public string[] completedQuests = Array.Empty<string>(); public Vector3 position;
    }
    [Serializable] public sealed class PersistentWorldData
    {
        public int schemaVersion = 1; public int day = 1; public int minuteOfDay = 420; public string weatherId = "clear"; public string[] npcIds = Array.Empty<string>(); public string[] npcStates = Array.Empty<string>(); public string[] farmPlotJson = Array.Empty<string>(); public string[] propertyJson = Array.Empty<string>();
    }
    [Serializable] public sealed class PersistentSaveEnvelope
    {
        public int schemaVersion = 1; public string saveId; public string revision; public string createdAtUtc; public PersistentPlayerData player = new PersistentPlayerData(); public PersistentWorldData world = new PersistentWorldData();
    }
    public enum PersistenceFailure { None, NotAuthenticated, ValidationFailed, Conflict, NetworkUnavailable, SerializationFailed, WriteFailed, MigrationFailed, CorruptBackup }
    public readonly struct PersistenceResult { public readonly bool success; public readonly PersistenceFailure failure; public readonly string message; public PersistenceResult(bool ok, PersistenceFailure reason, string text) { success = ok; failure = reason; message = text; } public static PersistenceResult Ok() => new PersistenceResult(true, PersistenceFailure.None, string.Empty); public static PersistenceResult Fail(PersistenceFailure reason, string message) => new PersistenceResult(false, reason, message); }
}
