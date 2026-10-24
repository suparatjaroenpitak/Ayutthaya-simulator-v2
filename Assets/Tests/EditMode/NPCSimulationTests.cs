using NUnit.Framework;
using UnityEngine;
using AyutthayaSimulator.NPC;

public sealed class NPCSimulationTests
{
    [Test] public void LODRules_SelectExpectedBands()
    {
        Assert.AreEqual(NPCAISimulationLOD.Full, NPCLodRules.Evaluate(10, 40, 180));
        Assert.AreEqual(NPCAISimulationLOD.Medium, NPCLodRules.Evaluate(100, 40, 180));
        Assert.AreEqual(NPCAISimulationLOD.Abstract, NPCLodRules.Evaluate(300, 40, 180));
    }

    [Test] public void ScheduleEntry_HandlesOvernightWindow()
    {
        ScheduleEntry entry = new ScheduleEntry { startMinute = 1320, endMinute = 120 };
        Assert.IsTrue(entry.Contains(30));
        Assert.IsTrue(entry.Contains(1380));
        Assert.IsFalse(entry.Contains(600));
    }

    [Test] public void RelationshipStore_ClampsValues()
    {
        GameObject go = new GameObject("Relationship");
        NPCRelationshipStore store = go.AddComponent<NPCRelationshipStore>();
        store.Adjust("somchai", 500);
        Assert.AreEqual(100, store.Get("somchai"));
        store.Adjust("somchai", -500);
        Assert.AreEqual(-100, store.Get("somchai"));
        Object.DestroyImmediate(go);
    }
}
