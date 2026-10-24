using UnityEngine;

namespace AyutthayaSimulator.Farming
{
    public readonly struct FarmUIState
    {
        public readonly CropGrowthStage stage; public readonly float moisture; public readonly float quality; public readonly int level;
        public FarmUIState(CropGrowthStage s, float m, float q, int l) { stage = s; moisture = m; quality = q; level = l; }
    }

    public sealed class FarmUIModel : MonoBehaviour
    {
        [SerializeField] private FarmPlot selectedPlot;
        [SerializeField] private FarmProgression progression;
        public FarmUIState GetState() => new FarmUIState(selectedPlot == null ? CropGrowthStage.Empty : selectedPlot.Stage, selectedPlot == null ? 0f : selectedPlot.Moisture, selectedPlot == null ? 0f : selectedPlot.Quality, progression == null ? 0 : progression.Level);
    }
}
