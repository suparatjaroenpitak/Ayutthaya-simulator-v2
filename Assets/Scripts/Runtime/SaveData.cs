using System;
using System.IO;
using UnityEngine;

namespace AyutthayaSimulator.Runtime
{
    [Serializable]
    public sealed class SaveData
    {
        public int schemaVersion = 1;
        public string slotId;
        public string savedAtUtc;
        public Vector3 playerPosition;
        public float hunger;
        public float energy;
        public int money;
    }

    public static class SaveService
    {
        public static string GetPath(string slotId) => Path.Combine(Application.persistentDataPath, slotId + ".json");

        public static void Save(SaveData data)
        {
            data.savedAtUtc = DateTime.UtcNow.ToString("O");
            File.WriteAllText(GetPath(data.slotId), JsonUtility.ToJson(data, true));
        }

        public static bool TryLoad(string slotId, out SaveData data)
        {
            string path = GetPath(slotId);
            if (!File.Exists(path)) { data = null; return false; }
            data = JsonUtility.FromJson<SaveData>(File.ReadAllText(path));
            return data != null && data.schemaVersion == 1;
        }
    }
}
