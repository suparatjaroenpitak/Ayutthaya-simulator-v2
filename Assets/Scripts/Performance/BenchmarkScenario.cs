using System;
using UnityEngine;

namespace AyutthayaSimulator.Performance
{
    [CreateAssetMenu(menuName = "Ayutthaya/Performance/Benchmark Scenario", fileName = "BenchmarkScenario")]
    public sealed class BenchmarkScenario : ScriptableObject
    {
        public string scenarioId = "phase16-open-world-baseline";
        public string scenePath;
        public int seed = 1601;
        public int durationSeconds = 120;
        public int npcCount = 100;
        public int vehicleCount = 30;
        public int streamedTileCount = 4;
        public string rendererPath = "URP";
        public string hardwareDescription = "Record in the run bundle; do not invent here.";
        public string[] metrics = { "frame_time_ms", "draw_calls", "triangles", "gc_bytes", "physics_ms", "npc_updates", "streaming_ms", "network_bytes" };
    }
}
