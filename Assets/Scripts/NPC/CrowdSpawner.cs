using UnityEngine;

namespace AyutthayaSimulator.NPC
{
    public sealed class CrowdSpawner : MonoBehaviour
    {
        [SerializeField] private NPCPool pool;
        [SerializeField] private NPCProfile[] profiles = new NPCProfile[0];
        [SerializeField] private Transform[] spawnPoints = new Transform[0];
        [SerializeField] private int count = 20;
        [SerializeField] private float sampleRadius = 4f;
        public void Spawn()
        {
            if (pool == null || profiles.Length == 0) return;
            for (int i = 0; i < Mathf.Min(count, spawnPoints.Length); i++)
            {
                Transform point = spawnPoints[i];
                if (point == null || !UnityEngine.AI.NavMesh.SamplePosition(point.position, out UnityEngine.AI.NavMeshHit hit, sampleRadius, UnityEngine.AI.NavMesh.AllAreas)) continue;
                CivilianNPC npc = pool.Acquire(hit.position, point.rotation);
                npc.Initialize(profiles[i % profiles.Length]);
            }
        }
    }
}
