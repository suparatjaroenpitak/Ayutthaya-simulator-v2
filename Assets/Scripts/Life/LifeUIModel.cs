using UnityEngine;

namespace AyutthayaSimulator.Life
{
    public readonly struct LifeUIState
    {
        public readonly float hunger, energy, stamina, health; public readonly bool sleeping;
        public LifeUIState(LifeState state) { hunger = state.hunger; energy = state.energy; stamina = state.stamina; health = state.health; sleeping = state.sleeping; }
    }

    public sealed class LifeUIModel : MonoBehaviour
    {
        [SerializeField] private LifeSimulation simulation;
        public event System.Action<LifeUIState> Changed;
        private void OnEnable() { if (simulation != null) simulation.StateChanged += OnState; }
        private void OnDisable() { if (simulation != null) simulation.StateChanged -= OnState; }
        private void OnState(LifeState state) => Changed?.Invoke(new LifeUIState(state));
        public LifeUIState Snapshot() => new LifeUIState(simulation == null ? default : simulation.State);
    }
}
