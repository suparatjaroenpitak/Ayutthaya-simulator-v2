using UnityEngine;
using UnityEngine.UI;

namespace AyutthayaSimulator.UI
{
    public sealed class UiTextOverflowValidator : MonoBehaviour
    {
        [SerializeField] private Text text;
        [SerializeField] private RectTransform bounds;
        public bool Fits() { if (text == null || bounds == null) return true; Canvas.ForceUpdateCanvases(); return text.preferredWidth <= bounds.rect.width + 0.5f && text.preferredHeight <= bounds.rect.height + 0.5f; }
    }
}
