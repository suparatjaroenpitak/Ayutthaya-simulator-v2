using UnityEngine;
using UnityEngine.AI;

namespace AyutthayaSimulator.NPC
{
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class TrafficSafePedestrian : MonoBehaviour
    {
        [SerializeField] private LayerMask vehicleMask;
        [SerializeField] private float lookAhead = 3f;
        [SerializeField] private float safetyRadius = 1.2f;
        private NavMeshAgent agent;
        private void Awake() => agent = GetComponent<NavMeshAgent>();
        private void Update()
        {
            if (agent == null || !agent.hasPath || agent.isStopped) return;
            Vector3 direction = agent.steeringTarget - transform.position;
            if (direction.sqrMagnitude < 0.01f) return;
            bool vehicleNear = Physics.SphereCast(transform.position + Vector3.up * 0.5f, safetyRadius, direction.normalized, out _, lookAhead, vehicleMask, QueryTriggerInteraction.Ignore);
            agent.isStopped = vehicleNear;
        }
    }
}
