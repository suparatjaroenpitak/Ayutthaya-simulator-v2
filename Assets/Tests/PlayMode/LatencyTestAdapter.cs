using UnityEngine;

namespace AyutthayaSimulator.QA
{
    public sealed class LatencyTestAdapter : MonoBehaviour
    {
        [SerializeField] private int simulatedLatencyMs = 100;
        [SerializeField] private int packetLossPercent;
        public int SimulatedLatencyMs => simulatedLatencyMs;
        public int PacketLossPercent => packetLossPercent;
        public bool ShouldDrop(int deterministicSequence) => packetLossPercent > 0 && Mathf.Abs(deterministicSequence) % 100 < packetLossPercent;
    }
}
