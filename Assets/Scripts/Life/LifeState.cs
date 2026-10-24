using System;
using UnityEngine;

namespace AyutthayaSimulator.Life
{
    [Serializable]
    public struct LifeState
    {
        [Range(0, 100)] public float hunger;
        [Range(0, 100)] public float energy;
        [Range(0, 100)] public float stamina;
        [Range(0, 100)] public float health;
        public bool sleeping;
        public LifeState(float maxHunger, float maxEnergy, float maxStamina, float maxHealth) { hunger = maxHunger; energy = maxEnergy; stamina = maxStamina; health = maxHealth; sleeping = false; }
    }

    [Serializable]
    public sealed class LifeSaveData
    {
        public int schemaVersion = 1;
        public LifeState state;
        public int day = 1;
        public int minuteOfDay = 420;
    }
}
