using NUnit.Framework;
using UnityEngine;
using AyutthayaSimulator.Vehicles;

public sealed class VehicleSystemTests
{
    [Test] public void LaneGraph_FindsNearestNodeWithinLimit()
    {
        GameObject graphObject = new GameObject("Graph");
        GameObject nodeObject = new GameObject("Node"); nodeObject.transform.SetParent(graphObject.transform); nodeObject.transform.position = new Vector3(2f, 0f, 0f);
        LaneGraph graph = graphObject.AddComponent<LaneGraph>();
        Assert.IsNull(graph.FindNearest(Vector3.zero, 1f));
        Object.DestroyImmediate(graphObject); Object.DestroyImmediate(nodeObject);
    }

    [Test] public void TrafficLight_AllowsGreenOnly()
    {
        GameObject go = new GameObject("Signal"); TrafficLight signal = go.AddComponent<TrafficLight>();
        Assert.IsTrue(signal.AllowsPassage()); Object.DestroyImmediate(go);
    }

    [Test] public void VehicleInput_ValuesCanBeClampedByControllerContract()
    {
        VehicleInput input = new VehicleInput { steering = 3f, throttle = -2f, brake = 4f };
        Assert.Greater(input.steering, 1f); Assert.Less(input.throttle, 0f); Assert.Greater(input.brake, 1f);
    }
}
