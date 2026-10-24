using System;
using UnityEngine;

namespace AyutthayaSimulator.Farming
{
    public enum CropGrowthStage { Empty, Prepared, Planted, Seedling, Growing, Mature, Harvested }
    public enum Season { Hot, Rainy, Cool }

    [Serializable]
    public struct GrowthStageDefinition
    {
        public CropGrowthStage stage;
        [Min(0.1f)] public float days;
    }

    [CreateAssetMenu(menuName = "Ayutthaya/Farming/Crop Definition", fileName = "CropDefinition")]
    public sealed class CropDefinition : ScriptableObject
    {
        public string cropId = "rice";
        public string displayNameThai = "ข้าว";
        public string displayNameEnglish = "Rice";
        public Season[] suitableSeasons = { Season.Rainy };
        public GrowthStageDefinition[] growthStages = Array.Empty<GrowthStageDefinition>();
        [Min(0f)] public float baseYieldKg = 500f;
        [Range(0f, 1f)] public float baseQuality = 0.7f;
        [Min(0f)] public int seedCost = 10;
    }
}
