using NUnit.Framework;
using UnityEngine;
using AyutthayaSimulator.Persistence;

public sealed class PersistenceTests
{
    [Test] public void SaveMigration_UpdatesNestedVersions()
    {
        PersistentSaveEnvelope data = new PersistentSaveEnvelope { schemaVersion = 1, player = new PersistentPlayerData { schemaVersion = 1 }, world = new PersistentWorldData { schemaVersion = 1 } };
        PersistenceResult result = SaveMigrationRunner.Upgrade(data, 2, new ISaveMigration[] { new SaveMigrationV1ToV2() }); Assert.IsTrue(result.success); Assert.AreEqual(2, data.schemaVersion); Assert.AreEqual(2, data.player.schemaVersion);
    }
    [Test] public void SaveMigration_FailsWhenPathMissing() { PersistentSaveEnvelope data = new PersistentSaveEnvelope { schemaVersion = 1 }; PersistenceResult result = SaveMigrationRunner.Upgrade(data, 3, new ISaveMigration[] { new SaveMigrationV1ToV2() }); Assert.IsFalse(result.success); Assert.AreEqual(PersistenceFailure.MigrationFailed, result.failure); }
    [Test] public void Envelope_RoundTripsJson() { PersistentSaveEnvelope source = new PersistentSaveEnvelope { saveId = "slot_01", player = new PersistentPlayerData { walletSatang = 1234 } }; PersistentSaveEnvelope result = JsonUtility.FromJson<PersistentSaveEnvelope>(JsonUtility.ToJson(source)); Assert.AreEqual(1234, result.player.walletSatang); }
}
