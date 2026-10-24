namespace AyutthayaSimulator.Persistence
{
    public interface ISaveMigration { int FromVersion { get; } int ToVersion { get; } PersistenceResult Migrate(PersistentSaveEnvelope data); }
    public sealed class SaveMigrationV1ToV2 : ISaveMigration
    {
        public int FromVersion => 1; public int ToVersion => 2;
        public PersistenceResult Migrate(PersistentSaveEnvelope data) { if (data == null || data.schemaVersion != 1) return PersistenceResult.Fail(PersistenceFailure.MigrationFailed, "Unexpected source schema."); data.schemaVersion = 2; data.player.schemaVersion = 2; data.world.schemaVersion = 2; return PersistenceResult.Ok(); }
    }
    public static class SaveMigrationRunner
    {
        public static PersistenceResult Upgrade(PersistentSaveEnvelope data, int targetVersion, ISaveMigration[] migrations)
        {
            if (data == null) return PersistenceResult.Fail(PersistenceFailure.MigrationFailed, "Save is null.");
            while (data.schemaVersion < targetVersion)
            {
                bool moved = false; for (int i = 0; i < migrations.Length; i++) if (migrations[i].FromVersion == data.schemaVersion) { PersistenceResult result = migrations[i].Migrate(data); if (!result.success) return result; moved = true; break; }
                if (!moved) return PersistenceResult.Fail(PersistenceFailure.MigrationFailed, "No migration exists for schema " + data.schemaVersion);
            }
            return data.schemaVersion == targetVersion ? PersistenceResult.Ok() : PersistenceResult.Fail(PersistenceFailure.MigrationFailed, "Save schema is newer than client.");
        }
    }
}
