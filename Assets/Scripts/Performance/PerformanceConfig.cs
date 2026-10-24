using UnityEngine;

namespace AyutthayaSimulator.Performance
{
    [CreateAssetMenu(menuName = "Ayutthaya/Performance/Quality Preset", fileName = "QualityPreset")]
    public sealed class QualityPreset : ScriptableObject
    {
        public string presetId = "medium";
        [Range(0.25f, 1f)] public float renderScale = 1f;
        [Range(0.1f, 1f)] public float terrainDetailDistance = 0.7f;
        [Range(0.1f, 1f)] public float npcSimulationDistance = 0.7f;
        [Min(0)] public int npcUpdatesPerFrame = 32;
        [Min(0)] public int shadowCascades = 2;
        public bool enableOcclusion = true;
        public bool enableGpuInstancing = true;
    }
}
