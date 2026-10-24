using System;
using UnityEngine;

namespace AyutthayaSimulator.UI
{
    public readonly struct UiNotification { public readonly string key; public readonly string fallback; public readonly float seconds; public UiNotification(string k, string f, float s) { key = k; fallback = f; seconds = s; } }
    public sealed class UiEventBus : MonoBehaviour
    {
        public event Action<UiNotification> NotificationRaised;
        public event Action<UiPanelId, bool> PanelChanged;
        public void Notify(string key, string fallback, float seconds = 3f) => NotificationRaised?.Invoke(new UiNotification(key, fallback, seconds));
        public void SetPanel(UiPanelId panel, bool visible) => PanelChanged?.Invoke(panel, visible);
    }
}
