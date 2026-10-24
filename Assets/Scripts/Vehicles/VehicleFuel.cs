using UnityEngine;

namespace AyutthayaSimulator.Vehicles
{
    public sealed class VehicleFuel : MonoBehaviour
    {
        [SerializeField] private VehicleDefinition definition;
        [SerializeField] private float litres;
        public float Litres => litres;
        public bool HasFuel => litres > 0.01f;
        public void Initialize(VehicleDefinition vehicle) { definition = vehicle; litres = definition == null ? 0f : definition.fuelCapacityLitres; }
        public void Consume(float throttle, float seconds)
        {
            if (definition == null || throttle <= 0f || !HasFuel) return;
            litres = Mathf.Max(0f, litres - definition.fuelBurnLitresPerSecond * throttle * seconds);
        }
        public bool Refuel(float amount) { if (definition == null || amount <= 0f) return false; litres = Mathf.Min(definition.fuelCapacityLitres, litres + amount); return true; }
    }
}
