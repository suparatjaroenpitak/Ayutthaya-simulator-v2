using UnityEngine;

namespace AyutthayaSimulator.Vehicles
{
    public sealed class Intersection : MonoBehaviour
    {
        [SerializeField] private TrafficLight[] signals = new TrafficLight[0];
        public bool CanEnter(int signalIndex) => signalIndex >= 0 && signalIndex < signals.Length && signals[signalIndex] != null && signals[signalIndex].AllowsPassage();
    }
}
