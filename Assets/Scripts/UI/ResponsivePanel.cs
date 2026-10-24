using UnityEngine;

namespace AyutthayaSimulator.UI
{
    public sealed class ResponsivePanel : MonoBehaviour
    {
        [SerializeField] private UiPanelId panelId;
        [SerializeField] private GameObject content;
        [SerializeField] private float compactWidth = 900f;
        public void SetVisible(bool visible) { if (content != null) content.SetActive(visible); }
        public void ApplyLayout(float width) { if (content == null) return; RectTransform rect = content.GetComponent<RectTransform>(); if (rect != null) rect.localScale = width < compactWidth ? Vector3.one * 0.9f : Vector3.one; }
        public UiPanelId PanelId => panelId;
    }
}
