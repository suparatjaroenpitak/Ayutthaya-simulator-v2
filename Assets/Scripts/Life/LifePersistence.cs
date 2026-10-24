using System.IO;
using UnityEngine;

namespace AyutthayaSimulator.Life
{
    public static class LifePersistence
    {
        public static string GetPath(string slot) => Path.Combine(Application.persistentDataPath, slot + ".life.json");
        public static void Save(string slot, LifeSaveData data) => File.WriteAllText(GetPath(slot), JsonUtility.ToJson(data, true));
        public static bool TryLoad(string slot, out LifeSaveData data) { string path = GetPath(slot); if (!File.Exists(path)) { data = null; return false; } data = JsonUtility.FromJson<LifeSaveData>(File.ReadAllText(path)); return data != null && data.schemaVersion == 1; }
    }
}
