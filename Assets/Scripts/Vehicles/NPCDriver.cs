using UnityEngine;

namespace AyutthayaSimulator.Vehicles
{
    [RequireComponent(typeof(VehicleController))]
    public sealed class NPCDriver : MonoBehaviour
    {
        [SerializeField] private LaneGraph graph;
        [SerializeField] private Intersection intersection;
        [SerializeField] private int signalIndex;
        private VehicleController vehicle;
        private LaneNode target;
        private void Awake() { vehicle = GetComponent<VehicleController>(); target = graph == null ? null : graph.FindNearest(transform.position, 100f); }
        private void FixedUpdate()
        {
            if (target == null) return;
            Vector3 local = transform.InverseTransformPoint(target.Position);
            float steering = Mathf.Clamp(local.x / 4f, -1f, 1f);
            float distance = local.magnitude;
            bool blocked = intersection != null && !intersection.CanEnter(signalIndex) && distance < 12f;
            vehicle.SetInput(new VehicleInput { steering = steering, throttle = blocked ? 0f : 1f, brake = blocked ? 1f : 0f }, gameObject);
            if (distance < 4f && target.next.Length > 0) target = target.next[Random.Range(0, target.next.Length)];
        }
    }
}
