using UnityEngine;

namespace AyutthayaSimulator.Performance
{
    public sealed class WorldStreamingBudget : MonoBehaviour
    {
        [SerializeField] private int maxTileOperationsPerFrame = 1;
        public int MaxTileOperationsPerFrame => maxTileOperationsPerFrame;
        public bool CanStartOperation(int operationsStartedThisFrame) => operationsStartedThisFrame < maxTileOperationsPerFrame;
    }
}
