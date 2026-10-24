using NUnit.Framework;
using UnityEngine;
using AyutthayaSimulator.GIS;

public sealed class GeoReferenceTests
{
    [Test]
    public void RoundTrip_PreservesLocalCoordinateWithinFloatTolerance()
    {
        GeoReference reference = new GeoReference { originLatitude = 14.3532, originLongitude = 100.5684, metersPerUnit = 1 };
        Vector3 local = new Vector3(120.5f, 4.25f, -80.25f);
        GeoCoordinate geo = reference.ToGeo(local);
        Vector3 roundTrip = reference.ToUnity(geo);
        Assert.That(Vector3.Distance(local, roundTrip), Is.LessThan(0.01f));
    }
}
