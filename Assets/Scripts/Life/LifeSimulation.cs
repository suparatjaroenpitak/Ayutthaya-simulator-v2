using UnityEngine;

namespace AyutthayaSimulator.Life
{
    public sealed class LifeSimulation : MonoBehaviour
    {
        [SerializeField] private LifeBalanceConfig balance;
        [SerializeField] private LifeClock clock;
        [SerializeField] private MonoBehaviour weatherProvider;
        public LifeState State { get; private set; }
        public event System.Action<LifeState> StateChanged;
        private IWeatherProvider weather;
        private void Awake() { weather = weatherProvider as IWeatherProvider; if (balance != null) State = new LifeState(balance.maxHunger, balance.maxEnergy, balance.maxStamina, balance.maxHealth); }
        private void Update() { if (balance == null || State.sleeping) return; SimulateMinutes(Time.deltaTime / 60f); }
        public void SimulateMinutes(float minutes)
        {
            if (balance == null || minutes <= 0f) return;
            float modifier = weather == null ? 1f : weather.EnergyModifier;
            State.hunger = Mathf.Clamp(State.hunger - balance.hungerDrain * minutes, 0f, balance.maxHunger);
            State.energy = Mathf.Clamp(State.energy - balance.energyDrain * modifier * minutes, 0f, balance.maxEnergy);
            State.stamina = Mathf.Clamp(State.stamina + balance.staminaRecovery * minutes, 0f, balance.maxStamina);
            if (State.hunger > balance.lowNeedRecoveryThreshold && State.energy > balance.lowNeedRecoveryThreshold) State.health = Mathf.Clamp(State.health + balance.passiveHealthRecovery * minutes, 0f, balance.maxHealth);
            StateChanged?.Invoke(State);
        }
        public bool Eat(float hungerRestore, float healthRestore = 0f) { if (hungerRestore <= 0f) return false; State.hunger = Mathf.Clamp(State.hunger + hungerRestore, 0f, balance.maxHunger); State.health = Mathf.Clamp(State.health + Mathf.Max(0f, healthRestore), 0f, balance.maxHealth); StateChanged?.Invoke(State); return true; }
        public bool Rest(float minutes) { if (minutes <= 0f) return false; State.energy = Mathf.Clamp(State.energy + balance.sleepEnergyRecovery * minutes / 60f, 0f, balance.maxEnergy); State.stamina = balance.maxStamina; StateChanged?.Invoke(State); return true; }
        public void SetSleeping(bool sleeping) => State.sleeping = sleeping;
        public void RecoverSafely() { State.hunger = Mathf.Max(State.hunger, balance.lowNeedRecoveryThreshold); State.energy = Mathf.Max(State.energy, balance.lowNeedRecoveryThreshold); State.stamina = balance.maxStamina; State.health = Mathf.Max(State.health, balance.lowNeedRecoveryThreshold); State.sleeping = false; StateChanged?.Invoke(State); }
        public LifeSaveData Capture() => new LifeSaveData { state = State, day = clock == null ? 1 : clock.Day, minuteOfDay = clock == null ? 420 : clock.MinuteOfDay };
        public void Restore(LifeSaveData data) { if (data == null || balance == null) return; State = data.state; State.hunger = Mathf.Clamp(State.hunger, 0f, balance.maxHunger); State.energy = Mathf.Clamp(State.energy, 0f, balance.maxEnergy); State.stamina = Mathf.Clamp(State.stamina, 0f, balance.maxStamina); State.health = Mathf.Clamp(State.health, 0f, balance.maxHealth); clock?.SetTime(data.day, data.minuteOfDay); StateChanged?.Invoke(State); }
    }
}
