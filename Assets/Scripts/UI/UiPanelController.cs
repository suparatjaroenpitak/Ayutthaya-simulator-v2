using System.Collections.Generic;
using UnityEngine;

namespace AyutthayaSimulator.UI
{
    public sealed class UiPanelController : MonoBehaviour
    {
        [SerializeField] private UiEventBus bus;
        [SerializeField] private ResponsivePanel[] panels = new ResponsivePanel[0];
        private readonly Dictionary<UiPanelId, ResponsivePanel> lookup = new Dictionary<UiPanelId, ResponsivePanel>();
        private void Awake() { for (int i = 0; i < panels.Length; i++) if (panels[i] != null) lookup[panels[i].PanelId] = panels[i]; }
        private void OnEnable() { if (bus != null) bus.PanelChanged += OnPanelChanged; }
        private void OnDisable() { if (bus != null) bus.PanelChanged -= OnPanelChanged; }
        private void OnPanelChanged(UiPanelId id, bool visible) { if (lookup.TryGetValue(id, out ResponsivePanel panel)) panel.SetVisible(visible); }
        private void OnRectTransformDimensionsChange() { foreach (ResponsivePanel panel in panels) if (panel != null) panel.ApplyLayout(Screen.width); }
    }
}
