using System.Collections.Generic;
using Unity.Profiling;
using UnityEngine;

namespace AyutthayaSimulator.NPC
{
    public sealed class NPCSimulationManager : MonoBehaviour
    {
        [SerializeField] private Transform[] players = new Transform[0];
        [SerializeField] private CivilianNPC[] civilians = new CivilianNPC[0];
        [SerializeField] private float fullDistance = 40f;
        [SerializeField] private float mediumDistance = 180f;
        [SerializeField] private int updatesPerFrame = 32;
        [SerializeField] private float gameMinutesPerSecond = 1f;
        [SerializeField] private int startMinute = 480;
        private int cursor;
        private float minuteAccumulator;
        private int currentMinute;
        private static readonly ProfilerMarker SimulationMarker = new ProfilerMarker("Ayutthaya.NPC.SimulationBudget");

        private void Awake() { currentMinute = startMinute; }
        private void Update()
        {
            minuteAccumulator += Time.deltaTime * gameMinutesPerSecond;
            if (minuteAccumulator >= 1f) { currentMinute = (currentMinute + Mathf.FloorToInt(minuteAccumulator)) % 1440; minuteAccumulator %= 1f; }
            if (civilians == null || civilians.Length == 0) return;
            using (SimulationMarker.Auto())
            {
                int count = Mathf.Min(Mathf.Max(1, updatesPerFrame), civilians.Length);
                for (int i = 0; i < count; i++)
                {
                    CivilianNPC npc = civilians[cursor]; cursor = (cursor + 1) % civilians.Length;
                    if (npc == null) continue;
                    npc.Simulate(currentMinute, NPCLodRules.Evaluate(NearestDistance(npc.transform.position), fullDistance, mediumDistance));
                }
            }
        }

        private float NearestDistance(Vector3 position)
        {
            float best = float.PositiveInfinity;
            for (int i = 0; i < players.Length; i++) if (players[i] != null) best = Mathf.Min(best, Vector3.Distance(position, players[i].position));
            return best;
        }

        public int CurrentMinute => currentMinute;
    }
}
