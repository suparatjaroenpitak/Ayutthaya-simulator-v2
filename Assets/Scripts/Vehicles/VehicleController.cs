using UnityEngine;

namespace AyutthayaSimulator.Vehicles
{
    [RequireComponent(typeof(Rigidbody), typeof(VehicleFuel))]
    public sealed class VehicleController : MonoBehaviour, IVehicleInteractable, IVehicleAuthority
    {
        [SerializeField] private VehicleDefinition definition;
        [SerializeField] private WheelCollider[] drivenWheels = new WheelCollider[0];
        [SerializeField] private WheelCollider[] steeringWheels = new WheelCollider[0];
        [SerializeField] private VehicleSeat driverSeat;
        [SerializeField] private VehicleSeat passengerSeat;
        [SerializeField] private VehicleAuthority authority = VehicleAuthority.Local;
        [SerializeField] private GameObject localDriver;
        private Rigidbody body;
        private VehicleFuel fuel;
        private VehicleInput input;
        public VehicleAuthority Authority => authority;
        public bool CanApplyInput(GameObject sender) => authority == VehicleAuthority.Server || (authority == VehicleAuthority.Local && (sender == localDriver || sender == gameObject));

        private void Awake()
        {
            body = GetComponent<Rigidbody>(); fuel = GetComponent<VehicleFuel>();
            if (definition != null) { body.mass = definition.mass; fuel.Initialize(definition); }
        }
        public void SetInput(VehicleInput nextInput, GameObject sender)
        {
            if (!CanApplyInput(sender)) return;
            input.steering = Mathf.Clamp(nextInput.steering, -1f, 1f);
            input.throttle = Mathf.Clamp01(nextInput.throttle);
            input.brake = Mathf.Clamp01(nextInput.brake);
            input.handbrake = nextInput.handbrake;
        }
        private void FixedUpdate()
        {
            if (definition == null || !fuel.HasFuel || driverSeat == null || !driverSeat.IsOccupied) { ApplyBrakes(definition == null ? 0f : definition.brakeForce * 0.25f); return; }
            float speedKph = body.velocity.magnitude * 3.6f;
            float speedFactor = Mathf.Clamp01(1f - speedKph / definition.maxSpeedKph);
            for (int i = 0; i < steeringWheels.Length; i++) steeringWheels[i].steerAngle = input.steering * definition.steeringLimitDegrees;
            for (int i = 0; i < drivenWheels.Length; i++) drivenWheels[i].motorTorque = definition.engineForce * input.throttle * speedFactor;
            ApplyBrakes(input.brake * definition.brakeForce + (input.handbrake ? definition.brakeForce : 0f));
            fuel.Consume(input.throttle, Time.fixedDeltaTime);
        }
        private void ApplyBrakes(float force) { for (int i = 0; i < drivenWheels.Length; i++) drivenWheels[i].brakeTorque = force; }
        public bool TryEnter(GameObject actor) { if (driverSeat == null || !driverSeat.TryEnter(actor)) return false; localDriver = actor; return true; }
        public void ExitDriver() { if (driverSeat != null && driverSeat.Occupant != null) driverSeat.Exit(driverSeat.Occupant); localDriver = null; input = default; }
    }
}
