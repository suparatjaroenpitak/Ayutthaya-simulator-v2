using UnityEngine;

namespace AyutthayaSimulator.Performance
{
    public interface IBudgetedSimulation { void SimulateBudgeted(); }
    public sealed class AITickBudget : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour[] agents = new MonoBehaviour[0];
        [SerializeField] private int updatesPerFrame = 32;
        private int cursor;
        private void Update() { int count = Mathf.Min(Mathf.Max(0, updatesPerFrame), agents.Length); for (int i = 0; i < count; i++) { MonoBehaviour agent = agents[cursor++ % agents.Length]; if (agent is IBudgetedSimulation simulation) simulation.SimulateBudgeted(); } }
    }
}
