using NUnit.Framework;
using UnityEngine;
using AyutthayaSimulator.Economy;
using AyutthayaSimulator.Farming;
using AyutthayaSimulator.Narrative;
using AyutthayaSimulator.Persistence;
using AyutthayaSimulator.Performance;
using AyutthayaSimulator.Server;

public sealed class QATestContracts
{
    [Test] public void EconomyRejectsNegativeAmounts() { GameObject go = new GameObject("Ledger"); EconomyLedger ledger = go.AddComponent<EconomyLedger>(); Assert.IsFalse(ledger.Validate("a", EconomyTransactionType.Wage, -1, "x")); Object.DestroyImmediate(go); }
    [Test] public void FarmingRejectsEmptyHarvest() { GameObject go = new GameObject("Plot"); FarmPlot plot = go.AddComponent<FarmPlot>(); Assert.IsFalse(plot.TryHarvest(out HarvestedProduce _)); Object.DestroyImmediate(go); }
    [Test] public void QuestStateReplayIsSafe() { StoryState state = new StoryState(); state.MarkCompleted("q"); state.MarkCompleted("q"); Assert.AreEqual(1, state.completedQuests.Length); }
    [Test] public void PersistenceReportsUnknownMigration() { PersistentSaveEnvelope save = new PersistentSaveEnvelope { schemaVersion = 9 }; PersistenceResult result = SaveMigrationRunner.Upgrade(save, 10, new ISaveMigration[0]); Assert.IsFalse(result.success); Assert.AreEqual(PersistenceFailure.MigrationFailed, result.failure); }
    [Test] public void MovementRejectsInvalidDeltaTime() { GameObject go = new GameObject("Validator"); MovementSanityValidator validator = go.AddComponent<MovementSanityValidator>(); Assert.IsFalse(validator.Accept("a", Vector3.zero, 0f)); Object.DestroyImmediate(go); }
}
