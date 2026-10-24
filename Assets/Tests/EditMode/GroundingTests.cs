using NUnit.Framework;
using UnityEngine;
using AyutthayaSimulator.Runtime;

public sealed class GroundingTests
{
    [Test]
    public void SpawnFallback_ReturnsRequestedPositionWithoutSurface()
    {
        Vector3 requested = new Vector3(4f, 2f, 8f);
        bool found = Grounding.TryFindSpawn(requested, 3f, 20f, out Vector3 result);
        Assert.IsFalse(found);
        Assert.AreEqual(requested, result);
    }
}
