using NUnit.Framework;
using UnityEngine;
using AyutthayaSimulator.Performance;

public sealed class PerformanceTests
{
    [Test] public void StreamingBudget_RejectsOperationsOverBudget() { GameObject go = new GameObject("Budget"); WorldStreamingBudget budget = go.AddComponent<WorldStreamingBudget>(); Assert.IsTrue(budget.CanStartOperation(0)); Assert.IsFalse(budget.CanStartOperation(1)); Object.DestroyImmediate(go); }
    [Test] public void Scenario_ContainsDeterministicSeedAndMetrics() { BenchmarkScenario scenario = ScriptableObject.CreateInstance<BenchmarkScenario>(); Assert.AreNotEqual(0, scenario.seed); Assert.IsNotEmpty(scenario.metrics); Object.DestroyImmediate(scenario); }
}
