using UnityEngine;
using UnityEngine.AI;
using AyutthayaSimulator.Runtime;

namespace AyutthayaSimulator.NPC
{
    [RequireComponent(typeof(NavMeshAgent))]
    public sealed class CivilianNPC : MonoBehaviour
    {
        [SerializeField] private NPCProfile profile;
        [SerializeField] private Animator animator;
        [SerializeField] private float destinationTolerance = 1.2f;
        private NavMeshAgent agent;
        private NPCAISimulationLOD lod;
        private int currentMinute;
        private ScheduleEntry currentSchedule;
        private bool hasSchedule;
        private INPCActivityHandler activityHandler;

        private void Awake() { agent = GetComponent<NavMeshAgent>(); activityHandler = GetComponent<INPCActivityHandler>(); }
        public void Initialize(NPCProfile npcProfile) { profile = npcProfile; if (agent != null && profile != null) agent.speed = profile.walkSpeed; }

        public void Simulate(int minute, NPCAISimulationLOD newLod)
        {
            if (profile == null) return;
            lod = newLod; currentMinute = minute;
            if (!TrySelectSchedule(minute, out ScheduleEntry entry)) return;
            bool changed = !hasSchedule || entry.activity != currentSchedule.activity || entry.target != currentSchedule.target;
            currentSchedule = entry; hasSchedule = true;
            if (lod == NPCAISimulationLOD.Abstract)
            {
                if (agent.enabled) agent.enabled = false;
                return;
            }
            if (!agent.enabled) agent.enabled = true;
            if (!agent.isOnNavMesh && !NavMesh.SamplePosition(transform.position, out NavMeshHit hit, 5f, NavMesh.AllAreas)) return;
            if (!agent.isOnNavMesh) agent.Warp(hit.position);
            if (changed) BeginActivity(entry);
            if (lod == NPCAISimulationLOD.Full && currentSchedule.target != null && Vector3.Distance(transform.position, currentSchedule.target.position) > destinationTolerance)
                agent.SetDestination(currentSchedule.target.position);
            if (animator != null) animator.SetFloat("Speed", agent.velocity.magnitude);
        }

        public bool TrySelectSchedule(int minute, out ScheduleEntry entry)
        {
            if (profile != null)
                for (int i = 0; i < profile.schedule.Length; i++) if (profile.schedule[i].Contains(minute)) { entry = profile.schedule[i]; return true; }
            entry = default; return false;
        }

        private void BeginActivity(ScheduleEntry entry) => activityHandler?.BeginActivity(entry.activity, profile);
        public NPCAISimulationLOD CurrentLOD => lod;
        public int CurrentMinute => currentMinute;
    }
}
