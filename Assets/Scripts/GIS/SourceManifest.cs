using System;
using UnityEngine;

namespace AyutthayaSimulator.GIS
{
    [Serializable]
    public sealed class SourceManifest
    {
        public string datasetName;
        public string provider;
        public string license;
        public string attribution;
        public string sourceUrl;
        public string acquiredAtUtc;
        public string crs;
        public string horizontalAccuracyNote;
        public string verticalAccuracyNote;
        public string missingGeometryNote;
        public bool IsComplete => !string.IsNullOrWhiteSpace(datasetName) && !string.IsNullOrWhiteSpace(provider) && !string.IsNullOrWhiteSpace(license) && !string.IsNullOrWhiteSpace(attribution) && !string.IsNullOrWhiteSpace(crs);
    }

    [Serializable]
    public sealed class SourceManifestCollection
    {
        public SourceManifest[] sources = Array.Empty<SourceManifest>();
    }
}
