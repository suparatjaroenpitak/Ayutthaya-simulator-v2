using UnityEngine;

namespace AyutthayaSimulator.Vehicles
{
    public sealed class ParkingSpot : MonoBehaviour
    {
        [SerializeField] private Transform alignment;
        private VehicleController occupant;
        public bool IsFree => occupant == null;
        public bool TryPark(VehicleController vehicle)
        {
            if (vehicle == null || !IsFree) return false;
            occupant = vehicle;
            vehicle.transform.SetPositionAndRotation((alignment == null ? transform : alignment).position, (alignment == null ? transform : alignment).rotation);
            return true;
        }
        public void Vacate(VehicleController vehicle) { if (occupant == vehicle) occupant = null; }
    }
}
