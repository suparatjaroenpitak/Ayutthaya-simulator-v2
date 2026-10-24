using UnityEngine;

namespace AyutthayaSimulator.Property
{
    public enum PropertyType { House, RentalUnit, FarmLand, Shop }

    [CreateAssetMenu(menuName = "Ayutthaya/Property/Property Definition", fileName = "PropertyDefinition")]
    public sealed class PropertyDefinition : ScriptableObject
    {
        public string propertyId;
        public string displayNameThai;
        public string displayNameEnglish;
        public PropertyType type;
        [Min(0)] public long purchasePriceSatang;
        [Min(0)] public long rentPriceSatang;
        public string interiorScenePath;
        public bool canRent = true;
        public bool canPurchase = true;
    }
}
