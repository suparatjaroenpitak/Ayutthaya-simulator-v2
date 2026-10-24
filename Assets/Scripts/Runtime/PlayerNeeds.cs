using UnityEngine;

namespace AyutthayaSimulator.Runtime
{
    public sealed class PlayerNeeds : MonoBehaviour
    {
        [SerializeField] private GameConfig config;
        public float Hunger { get; private set; }
        public float Energy { get; private set; }

        public void Initialize(GameConfig gameConfig)
        {
            config = gameConfig;
            Hunger = config.maxHunger;
            Energy = config.maxEnergy;
        }

        private void Update()
        {
            if (config == null) return;
            float minutes = Time.deltaTime / 60f;
            Hunger = Mathf.Max(0f, Hunger - config.hungerDrainPerMinute * minutes);
            Energy = Mathf.Max(0f, Energy - config.energyDrainPerMinute * minutes);
        }

        public void Restore(float hunger, float energy)
        {
            Hunger = Mathf.Clamp(hunger, 0f, config.maxHunger);
            Energy = Mathf.Clamp(energy, 0f, config.maxEnergy);
        }
    }
}
