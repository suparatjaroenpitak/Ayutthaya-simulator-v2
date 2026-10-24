using UnityEngine;

namespace AyutthayaSimulator.Performance
{
    public sealed class QualityPresetRuntime : MonoBehaviour
    {
        [SerializeField] private QualityPreset preset;
        public void Apply() { if (preset == null) return; QualitySettings.lodBias = Mathf.Max(0.1f, preset.terrainDetailDistance); QualitySettings.shadowCascades = preset.shadowCascades; }
    }
}
