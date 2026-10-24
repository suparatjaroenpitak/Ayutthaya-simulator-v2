using UnityEngine;

namespace AyutthayaSimulator.Animation
{
    public sealed class AnimationEventRelay : MonoBehaviour
    {
        public event System.Action<string> EventReceived;
        public void Relay(string eventName) => EventReceived?.Invoke(eventName);
    }
}
