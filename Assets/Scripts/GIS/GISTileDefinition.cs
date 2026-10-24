using System;
using UnityEngine;

namespace AyutthayaSimulator.GIS
{
    [CreateAssetMenu(menuName = "Ayutthaya/GIS/Tile Definition", fileName = "GISTileDefinition")]
    public sealed class GISTileDefinition : ScriptableObject
    {
        public string tileId;
        public BoundsGeo bounds;
        public string scenePath;
        public string terrainSourcePath;
        public string roadsSourcePath;
        public string riversSourcePath;
        public string buildingsSourcePath;
        public string landUseSourcePath;
        public int lod;
        public bool IsValid => !string.IsNullOrWhiteSpace(tileId) && bounds.IsValid && !string.IsNullOrWhiteSpace(scenePath);
    }

    [Serializable]
    public struct GeoSpawnPoint
    {
        public string id;
        public double latitude;
        public double longitude;
        public float elevationMeters;
        public string category;
    }
}
