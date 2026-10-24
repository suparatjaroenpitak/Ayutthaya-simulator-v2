using UnityEngine;

namespace AyutthayaSimulator.Vehicles
{
    public enum TrafficSignal { Red, Amber, Green }
    public sealed class TrafficLight : MonoBehaviour
    {
        [SerializeField] private float greenSeconds = 20f;
        [SerializeField] private float amberSeconds = 3f;
        [SerializeField] private float redSeconds = 20f;
        private float timer;
        public TrafficSignal Signal { get; private set; } = TrafficSignal.Green;
        private void Update()
        {
            timer += Time.deltaTime;
            float duration = Signal == TrafficSignal.Green ? greenSeconds : Signal == TrafficSignal.Amber ? amberSeconds : redSeconds;
            if (timer < duration) return;
            timer = 0f; Signal = Signal == TrafficSignal.Green ? TrafficSignal.Amber : Signal == TrafficSignal.Amber ? TrafficSignal.Red : TrafficSignal.Green;
        }
        public bool AllowsPassage() => Signal == TrafficSignal.Green;
    }
}
