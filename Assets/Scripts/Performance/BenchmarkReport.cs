using System;
using System.Collections.Generic;
using UnityEngine;

namespace AyutthayaSimulator.Performance
{
    [Serializable] public sealed class BenchmarkReport { public string scenarioId; public string runId; public string capturedAtUtc; public string hardware; public List<BenchmarkSample> samples = new List<BenchmarkSample>(); public string[] limitations = { "Unity Editor capture required", "No FPS result is valid until sealed telemetry is verified" }; }
    public sealed class BenchmarkReportWriter : MonoBehaviour
    {
        [SerializeField] private BenchmarkScenario scenario;
        [SerializeField] private PerformanceTelemetry telemetry;
        public BenchmarkReport Current { get; private set; }
        private void OnEnable() { if (telemetry != null) telemetry.SampleCaptured += Add; Current = new BenchmarkReport { scenarioId = scenario == null ? "unknown" : scenario.scenarioId, runId = Guid.NewGuid().ToString("N"), capturedAtUtc = DateTime.UtcNow.ToString("O"), hardware = scenario == null ? string.Empty : scenario.hardwareDescription }; }
        private void OnDisable() { if (telemetry != null) telemetry.SampleCaptured -= Add; }
        private void Add(BenchmarkSample sample) => Current.samples.Add(sample);
    }
}
