using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using AyutthayaSimulator.GIS;

namespace AyutthayaSimulator.Editor
{
    public static class GISTileValidator
    {
        [MenuItem("Ayutthaya/GIS/Validate Project Config")]
        public static void ValidateSelected()
        {
            GISProjectConfig config = Selection.activeObject as GISProjectConfig;
            if (config == null) { Debug.LogError("Select a GISProjectConfig asset first."); return; }
            List<string> errors = new List<string>();
            if (string.IsNullOrWhiteSpace(config.projectId)) errors.Add("projectId is required.");
            if (!config.areaOfInterest.IsValid) errors.Add("Area of interest bounds are invalid or missing.");
            if (config.reference == null || config.reference.originLatitude == 0 && config.reference.originLongitude == 0) errors.Add("Origin is not configured; no geographic position will be invented.");
            string absolute = Path.Combine(Application.dataPath, config.sourceManifestPath.Replace("Assets/", string.Empty));
            if (!File.Exists(absolute)) errors.Add("Source manifest is missing: " + config.sourceManifestPath);
            if (errors.Count == 0) Debug.Log("GIS validation passed structural checks. It does not certify source accuracy.");
            else foreach (string error in errors) Debug.LogError("GIS validation: " + error);
        }
    }
}
