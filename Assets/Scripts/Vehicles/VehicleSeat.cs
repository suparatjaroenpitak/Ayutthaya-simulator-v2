using UnityEngine;

namespace AyutthayaSimulator.Vehicles
{
    public sealed class VehicleSeat : MonoBehaviour, IVehicleSeat
    {
        [SerializeField] private Transform sitPoint;
        [SerializeField] private Transform exitPoint;
        private GameObject occupant;
        public bool IsOccupied => occupant != null;
        public GameObject Occupant => occupant;
        public bool TryEnter(GameObject actor)
        {
            if (actor == null || IsOccupied) return false;
            occupant = actor;
            actor.transform.SetPositionAndRotation((sitPoint == null ? transform : sitPoint).position, (sitPoint == null ? transform : sitPoint).rotation);
            actor.SetActive(false);
            return true;
        }
        public void Exit(GameObject actor)
        {
            if (actor == null || actor != occupant) return;
            Transform point = exitPoint == null ? transform : exitPoint;
            actor.transform.SetPositionAndRotation(point.position, point.rotation);
            actor.SetActive(true);
            occupant = null;
        }
    }
}
