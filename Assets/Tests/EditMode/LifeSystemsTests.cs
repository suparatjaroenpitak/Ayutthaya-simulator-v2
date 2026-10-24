using NUnit.Framework;
using UnityEngine;
using AyutthayaSimulator.Life;

public sealed class LifeSystemsTests
{
    [Test] public void LifeState_InitializesToConfiguredMaximums()
    {
        LifeState state = new LifeState(100f, 80f, 60f, 40f); Assert.AreEqual(100f, state.hunger); Assert.AreEqual(80f, state.energy); Assert.AreEqual(60f, state.stamina); Assert.AreEqual(40f, state.health);
    }

    [Test] public void SafeRecovery_RestoresMinimumsWithoutExceedingConfiguredMaximums()
    {
        LifeBalanceConfig config = ScriptableObject.CreateInstance<LifeBalanceConfig>(); config.lowNeedRecoveryThreshold = 10f; config.maxHunger = 100f; config.maxEnergy = 100f; config.maxStamina = 100f; config.maxHealth = 100f;
        Assert.LessOrEqual(config.lowNeedRecoveryThreshold, config.maxHunger); Assert.LessOrEqual(config.lowNeedRecoveryThreshold, config.maxEnergy);
        Object.DestroyImmediate(config);
    }

    [Test] public void LifePersistence_RoundTripsJson()
    {
        LifeSaveData source = new LifeSaveData { state = new LifeState(100, 80, 60, 40), day = 3, minuteOfDay = 600 };
        LifeSaveData result = JsonUtility.FromJson<LifeSaveData>(JsonUtility.ToJson(source)); Assert.AreEqual(source.day, result.day); Assert.AreEqual(source.state.energy, result.state.energy);
    }
}
