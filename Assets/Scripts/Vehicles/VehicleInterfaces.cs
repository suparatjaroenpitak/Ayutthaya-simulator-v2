using UnityEngine;

namespace AyutthayaSimulator.Vehicles
{
    public enum VehicleKind { Car, Motorcycle }
    public enum VehicleAuthority { Local, Server, Remote }

    public interface IVehicleInputSource { VehicleInput ReadInput(); }
    public interface IVehicleAuthority { VehicleAuthority Authority { get; } bool CanApplyInput(GameObject sender); }
    public interface IVehicleSeat { bool IsOccupied { get; } bool TryEnter(GameObject actor); void Exit(GameObject actor); }
    public interface IVehicleInteractable { bool TryEnter(GameObject actor); }

    public struct VehicleInput
    {
        public float steering;
        public float throttle;
        public float brake;
        public bool handbrake;
    }
}
