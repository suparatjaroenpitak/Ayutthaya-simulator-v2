using UnityEngine;

namespace AyutthayaSimulator.Farming
{
    public sealed class FarmPlot : MonoBehaviour
    {
        [SerializeField] private CropDefinition crop;
        [SerializeField] private FarmWeatherService weather;
        [SerializeField] private SeasonCalendar calendar;
        [SerializeField] private float moisture;
        [SerializeField] private float fertilizer;
        [SerializeField] private float growthDays;
        [SerializeField] private CropGrowthStage stage = CropGrowthStage.Empty;
        [Range(0f, 1f)] [SerializeField] private float quality = 1f;
        public CropGrowthStage Stage => stage;
        public float Moisture => moisture;
        public float Quality => quality;
        public string CropId => crop == null ? string.Empty : crop.cropId;
        public float GrowthDays => growthDays;
        public bool PrepareSoil() { if (stage != CropGrowthStage.Empty && stage != CropGrowthStage.Harvested) return false; stage = CropGrowthStage.Prepared; growthDays = 0f; quality = 1f; return true; }
        public bool Plant(CropDefinition definition) { if (stage != CropGrowthStage.Prepared || definition == null || (calendar != null && !calendar.IsSuitable(definition))) return false; crop = definition; stage = CropGrowthStage.Planted; return true; }
        public bool Irrigate(float amount) { if (stage == CropGrowthStage.Empty || amount <= 0f) return false; moisture = Mathf.Clamp01(moisture + amount); return true; }
        public bool Fertilize(float amount) { if (stage == CropGrowthStage.Empty || amount <= 0f) return false; fertilizer = Mathf.Clamp01(fertilizer + amount); return true; }
        public void SimulateDay()
        {
            if (crop == null || stage == CropGrowthStage.Empty || stage == CropGrowthStage.Harvested) return;
            if (weather != null) Irrigate(weather.IrrigationAmount);
            moisture = Mathf.Clamp01(moisture - 0.08f);
            float multiplier = weather == null ? 1f : weather.GrowthMultiplier;
            growthDays += multiplier * (moisture > 0.15f ? 1f : 0.35f);
            quality = Mathf.Clamp01(quality + fertilizer * 0.01f - (moisture < 0.1f ? 0.04f : 0f));
            stage = ResolveStage();
        }
        private CropGrowthStage ResolveStage()
        {
            float total = 0f;
            for (int i = 0; i < crop.growthStages.Length; i++) { total += crop.growthStages[i].days; if (growthDays < total) return crop.growthStages[i].stage; }
            return CropGrowthStage.Mature;
        }
        public bool TryHarvest(out HarvestedProduce produce)
        {
            if (crop == null || stage != CropGrowthStage.Mature) { produce = default; return false; }
            produce = new HarvestedProduce(crop.cropId, crop.baseYieldKg * quality, quality);
            stage = CropGrowthStage.Harvested; return true;
        }
    }

    public struct HarvestedProduce
    {
        public string cropId; public float kilograms; public float quality;
        public HarvestedProduce(string id, float kg, float q) { cropId = id; kilograms = kg; quality = q; }
    }
}
