using System.IO;
using UnityEngine;

namespace AyutthayaSimulator.Property
{
    public static class PropertyPersistence
    {
        public static string GetPath(string slot) => Path.Combine(Application.persistentDataPath, slot + ".property.json");
        public static void Save(string slot, PropertyState[] states) => File.WriteAllText(GetPath(slot), JsonUtility.ToJson(new PropertySaveData { schemaVersion = 1, states = states }, true));
        public static bool TryLoad(string slot, out PropertyState[] states) { string path = GetPath(slot); if (!File.Exists(path)) { states = null; return false; } PropertySaveData data = JsonUtility.FromJson<PropertySaveData>(File.ReadAllText(path)); states = data == null ? null : data.states; return data != null && data.schemaVersion == 1; }
    }
    [System.Serializable] public sealed class PropertySaveData { public int schemaVersion = 1; public PropertyState[] states = new PropertyState[0]; }
}
