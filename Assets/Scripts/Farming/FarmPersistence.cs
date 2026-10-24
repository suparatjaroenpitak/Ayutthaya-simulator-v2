using System;
using System.IO;
using UnityEngine;

namespace AyutthayaSimulator.Farming
{
    [Serializable]
    public struct FarmPlotSave
    {
        public string plotId;
        public string cropId;
        public CropGrowthStage stage;
        public float moisture;
        public float quality;
        public float growthDays;
    }

    [Serializable]
    public sealed class FarmSaveData
    {
        public int schemaVersion = 1;
        public FarmPlotSave[] plots = Array.Empty<FarmPlotSave>();
    }

    public static class FarmPersistence
    {
        public static string GetPath(string slot) => Path.Combine(Application.persistentDataPath, slot + ".farm.json");
        public static void Save(string slot, FarmSaveData data) => File.WriteAllText(GetPath(slot), JsonUtility.ToJson(data, true));
        public static bool TryLoad(string slot, out FarmSaveData data)
        {
            string path = GetPath(slot);
            if (!File.Exists(path)) { data = null; return false; }
            data = JsonUtility.FromJson<FarmSaveData>(File.ReadAllText(path));
            return data != null && data.schemaVersion == 1;
        }
    }
}
