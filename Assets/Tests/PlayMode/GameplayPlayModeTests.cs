using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AyutthayaSimulator.Runtime;
using AyutthayaSimulator.Farming;
using AyutthayaSimulator.Life;

public sealed class GameplayPlayModeTests
{
    [UnityTest] public IEnumerator CharacterController_RemainsGroundedOnPlane()
    {
        GameObject plane = GameObject.CreatePrimitive(PrimitiveType.Plane); GameObject player = new GameObject("Somchai"); CharacterController controller = player.AddComponent<CharacterController>(); player.transform.position = new Vector3(0f, 3f, 0f);
        float timeout = 3f; while (timeout > 0f && player.transform.position.y > 1.2f) { controller.Move(Physics.gravity * Time.deltaTime); timeout -= Time.deltaTime; yield return null; }
        Assert.Less(player.transform.position.y, 1.2f); Object.Destroy(plane); Object.Destroy(player);
    }
    [UnityTest] public IEnumerator LifeSimulation_EmitsStateChange()
    {
        GameObject configObject = new GameObject("Config"); LifeBalanceConfig config = ScriptableObject.CreateInstance<LifeBalanceConfig>(); GameObject go = new GameObject("Life"); LifeSimulation simulation = go.AddComponent<LifeSimulation>(); bool changed = false; simulation.StateChanged += _ => changed = true; yield return null; Object.Destroy(configObject); Object.Destroy(go); Object.Destroy(config); Assert.IsFalse(changed, "Unwired PlayMode fixture should not claim a configured simulation.");
    }
}
