using UnityEngine;

namespace AyutthayaSimulator.Vehicles
{
    [CreateAssetMenu(menuName = "Ayutthaya/Vehicles/Vehicle Definition", fileName = "VehicleDefinition")]
    public sealed class VehicleDefinition : ScriptableObject
    {
        public VehicleKind kind = VehicleKind.Car;
        [Min(1f)] public float mass = 1200f;
        [Min(1f)] public float engineForce = 7000f;
        [Min(1f)] public float brakeForce = 9000f;
        [Min(1f)] public float maxSpeedKph = 90f;
        [Min(0.1f)] public float fuelCapacityLitres = 45f;
        [Min(0f)] public float fuelBurnLitresPerSecond = 0.012f;
        [Min(0.1f)] public float steeringLimitDegrees = 28f;
    }
}
