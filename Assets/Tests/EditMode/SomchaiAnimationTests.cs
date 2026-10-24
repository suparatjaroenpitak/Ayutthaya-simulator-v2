using NUnit.Framework;
using UnityEngine;
using AyutthayaSimulator.Animation;

public sealed class SomchaiAnimationTests
{
    [Test]
    public void InteractionPoint_AlignsOnlyWhenInRange()
    {
        GameObject pointObject = new GameObject("Point");
        GameObject actor = new GameObject("Actor");
        InteractionPoint point = pointObject.AddComponent<InteractionPoint>();
        actor.transform.position = pointObject.transform.position;
        point.Align(actor.transform);
        Assert.AreEqual(point.Alignment.position, actor.transform.position);
        Object.DestroyImmediate(pointObject);
        Object.DestroyImmediate(actor);
    }

    [Test]
    public void ClothingSlot_RejectsUnknownVariantWithoutThrowing()
    {
        GameObject go = new GameObject("Clothing");
        ClothingCustomization customization = go.AddComponent<ClothingCustomization>();
        Assert.IsFalse(customization.Apply("missing", 0));
        Object.DestroyImmediate(go);
    }
}
