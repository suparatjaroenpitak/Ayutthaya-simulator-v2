using UnityEngine;

namespace AyutthayaSimulator.NPC
{
    public enum NPCAISimulationLOD { Full, Medium, Abstract }

    public static class NPCLodRules
    {
        public static NPCAISimulationLOD Evaluate(float nearestDistance, float fullDistance, float mediumDistance)
        {
            if (nearestDistance <= fullDistance) return NPCAISimulationLOD.Full;
            if (nearestDistance <= mediumDistance) return NPCAISimulationLOD.Medium;
            return NPCAISimulationLOD.Abstract;
        }
    }
}
