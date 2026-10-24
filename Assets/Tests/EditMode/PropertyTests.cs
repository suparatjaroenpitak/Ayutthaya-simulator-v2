using NUnit.Framework;
using UnityEngine;
using AyutthayaSimulator.Property;

public sealed class PropertyTests
{
    [Test] public void PropertyState_DefaultsToUnowned()
    {
        PropertyState state = new PropertyState { propertyId = "house_01" }; Assert.IsFalse(state.purchased); Assert.IsFalse(state.rented); Assert.IsTrue(string.IsNullOrEmpty(state.ownerId));
    }
    [Test] public void DecorationState_RoundTripsJson()
    {
        PropertySaveData source = new PropertySaveData { states = new[] { new PropertyState { propertyId = "house_01", ownerId = "somchai", purchased = true } } }; PropertySaveData result = JsonUtility.FromJson<PropertySaveData>(JsonUtility.ToJson(source)); Assert.AreEqual("somchai", result.states[0].ownerId); Assert.IsTrue(result.states[0].purchased);
    }
}
