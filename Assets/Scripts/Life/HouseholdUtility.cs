using UnityEngine;

namespace AyutthayaSimulator.Life
{
    public enum HouseholdUtilityType { Bed, Kitchen, Water, Electricity }
    public sealed class HouseholdUtility : MonoBehaviour
    {
        [SerializeField] private HouseholdUtilityType type;
        [SerializeField] private bool available = true;
        public HouseholdUtilityType Type => type;
        public bool Available => available;
        public void SetAvailable(bool value) => available = value;
        public bool CanUse() => available;
    }
}
