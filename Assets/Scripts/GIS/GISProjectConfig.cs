using System;
using UnityEngine;

namespace AyutthayaSimulator.GIS
{
    [CreateAssetMenu(menuName = "Ayutthaya/GIS/Project Config", fileName = "GISProjectConfig")]
    public sealed class GISProjectConfig : ScriptableObject
    {
        [Header("Required: do not invent these values")]
        public string projectId;
        public string coordinateReferenceSystem = "EPSG:4326 input; local ENU output";
        public GeoReference reference = new GeoReference();
        public BoundsGeo areaOfInterest;
        public string sourceManifestPath = "Assets/GIS/Sources/source-manifest.json";
        public string outputRoot = "Assets/World/Tiles";
        [Min(32)] public int tileSizeMeters = 512;
        [Min(1)] public int maxLod = 3;
        public bool requireLicensedSourceMetadata = true;
    }

    [Serializable]
    public struct BoundsGeo
    {
        public double minLatitude;
        public double minLongitude;
        public double maxLatitude;
        public double maxLongitude;
        public bool IsValid => minLatitude < maxLatitude && minLongitude < maxLongitude && minLatitude >= -90 && maxLatitude <= 90 && minLongitude >= -180 && maxLongitude <= 180;
    }
}
