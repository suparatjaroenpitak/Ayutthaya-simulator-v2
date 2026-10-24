using UnityEngine;

namespace AyutthayaSimulator.Life
{
    [CreateAssetMenu(menuName = "Ayutthaya/Life/Life Balance Config", fileName = "LifeBalanceConfig")]
    public sealed class LifeBalanceConfig : ScriptableObject
    {
        [Header("Maximums")]
        [Min(1f)] public float maxHunger = 100f;
        [Min(1f)] public float maxEnergy = 100f;
        [Min(1f)] public float maxStamina = 100f;
        [Min(1f)] public float maxHealth = 100f;
        [Header("Per real minute")]
        [Min(0f)] public float hungerDrain = 2f;
        [Min(0f)] public float energyDrain = 1f;
        [Min(0f)] public float staminaRecovery = 18f;
        [Min(0f)] public float sleepEnergyRecovery = 28f;
        [Min(0f)] public float sleepHealthRecovery = 3f;
        [Header("Recovery")]
        [Min(0f)] public float lowNeedRecoveryThreshold = 10f;
        [Min(0f)] public float passiveHealthRecovery = 0.5f;
    }
}
