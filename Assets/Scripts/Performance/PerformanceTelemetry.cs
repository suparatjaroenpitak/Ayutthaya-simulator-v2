using System;
using Unity.Profiling;
using UnityEngine;

namespace AyutthayaSimulator.Performance
{
    [Serializable] public struct BenchmarkSample { public float frameMs; public long drawCalls; public long triangles; public long gcBytes; public long physicsMs; public long networkBytes; }
    public sealed class PerformanceTelemetry : MonoBehaviour
    {
        [SerializeField] private bool capture;
        public event Action<BenchmarkSample> SampleCaptured;
        private ProfilerRecorder mainThread, drawCalls, triangles, gc;
        private float elapsed;
        private void OnEnable() { mainThread = ProfilerRecorder.StartNew(ProfilerCategory.Internal, "Main Thread", 15); drawCalls = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Draw Calls Count", 15); triangles = ProfilerRecorder.StartNew(ProfilerCategory.Render, "Triangles Count", 15); gc = ProfilerRecorder.StartNew(ProfilerCategory.Memory, "GC Reserved Memory", 15); }
        private void OnDisable() { mainThread.Dispose(); drawCalls.Dispose(); triangles.Dispose(); gc.Dispose(); }
        private void Update() { if (!capture) return; elapsed += Time.unscaledDeltaTime; if (elapsed < 0.25f) return; elapsed = 0f; SampleCaptured?.Invoke(new BenchmarkSample { frameMs = mainThread.LastValue / 1000000f, drawCalls = drawCalls.LastValue, triangles = triangles.LastValue, gcBytes = gc.LastValue }); }
        public void SetCapture(bool value) => capture = value;
    }
}
