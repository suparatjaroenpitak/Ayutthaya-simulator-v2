using System;
using UnityEngine;

namespace AyutthayaSimulator.Economy
{
    [CreateAssetMenu(menuName = "Ayutthaya/Economy/Product Definition", fileName = "ProductDefinition")]
    public sealed class ProductDefinition : ScriptableObject
    {
        public string productId;
        public string displayNameThai;
        public string displayNameEnglish;
        [Min(0.001f)] public float weightKg = 1f;
        public bool legal = true;
    }

    [Serializable]
    public struct PriceEntry
    {
        public string productId;
        [Min(0)] public long buyPriceSatang;
        [Min(0)] public long sellPriceSatang;
    }

    [CreateAssetMenu(menuName = "Ayutthaya/Economy/Price Book", fileName = "PriceBook")]
    public sealed class PriceBook : ScriptableObject
    {
        public PriceEntry[] entries = Array.Empty<PriceEntry>();
        public bool TryGet(string productId, out PriceEntry result) { for (int i = 0; i < entries.Length; i++) if (entries[i].productId == productId) { result = entries[i]; return true; } result = default; return false; }
    }
}
