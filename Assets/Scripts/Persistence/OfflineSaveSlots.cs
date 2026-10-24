using System;
using System.IO;
using UnityEngine;

namespace AyutthayaSimulator.Persistence
{
    public sealed class OfflineSaveSlots : MonoBehaviour
    {
        [SerializeField] private int currentSchema = 1;
        public PersistenceResult Save(string slotId, PersistentSaveEnvelope data)
        {
            if (string.IsNullOrWhiteSpace(slotId) || data == null) return PersistenceResult.Fail(PersistenceFailure.ValidationFailed, "Slot or data missing.");
            data.schemaVersion = currentSchema; data.saveId = slotId; data.createdAtUtc = DateTime.UtcNow.ToString("O");
            string path = Path.Combine(Application.persistentDataPath, slotId + ".save.json"); string temp = path + ".tmp"; string backup = path + ".bak";
            try { File.WriteAllText(temp, JsonUtility.ToJson(data, true)); if (File.Exists(path)) File.Copy(path, backup, true); File.Copy(temp, path, true); File.Delete(temp); return PersistenceResult.Ok(); }
            catch (Exception ex) { return PersistenceResult.Fail(PersistenceFailure.WriteFailed, ex.Message); }
        }
        public PersistenceResult Load(string slotId, out PersistentSaveEnvelope data)
        {
            data = null; string path = Path.Combine(Application.persistentDataPath, slotId + ".save.json"); string backup = path + ".bak";
            if (!TryRead(path, out data) && !TryRead(backup, out data)) return PersistenceResult.Fail(PersistenceFailure.CorruptBackup, "Primary and backup saves are unavailable or corrupt.");
            PersistenceResult migration = SaveMigrationRunner.Upgrade(data, currentSchema, new ISaveMigration[] { }); return migration.success ? migration : PersistenceResult.Fail(PersistenceFailure.MigrationFailed, migration.message);
        }
        private bool TryRead(string path, out PersistentSaveEnvelope data) { data = null; try { if (!File.Exists(path)) return false; data = JsonUtility.FromJson<PersistentSaveEnvelope>(File.ReadAllText(path)); return data != null; } catch { return false; } }
    }
}
