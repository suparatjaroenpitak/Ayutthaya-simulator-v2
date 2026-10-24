using System;
using UnityEngine;

namespace AyutthayaSimulator.Operations
{
    public interface IServerDrainHandler { void BeginDrain(); bool IsDrained { get; } }
    public sealed class GracefulServerShutdown : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour[] handlers = Array.Empty<MonoBehaviour>();
        public bool IsShuttingDown { get; private set; }
        public void BeginShutdown()
        {
            if (IsShuttingDown) return; IsShuttingDown = true;
            for (int i = 0; i < handlers.Length; i++) if (handlers[i] is IServerDrainHandler handler) handler.BeginDrain();
        }
        public bool AllDrained { get { for (int i = 0; i < handlers.Length; i++) if (handlers[i] is IServerDrainHandler handler && !handler.IsDrained) return false; return true; } }
    }
}
