using NUnit.Framework;
using UnityEngine;
using AyutthayaSimulator.Runtime;

public sealed class SaveServiceTests
{
    [Test]
    public void SaveData_RoundTripsJson()
    {
        SaveData source = new SaveData { schemaVersion = 1, slotId = "test", playerPosition = new Vector3(1, 2, 3), hunger = 80, energy = 60 };
        SaveData result = JsonUtility.FromJson<SaveData>(JsonUtility.ToJson(source));
        Assert.AreEqual(source.playerPosition, result.playerPosition);
        Assert.AreEqual(source.hunger, result.hunger);
        Assert.AreEqual(source.energy, result.energy);
    }
}
