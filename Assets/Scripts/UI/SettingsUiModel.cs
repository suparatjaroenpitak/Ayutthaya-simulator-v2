using UnityEngine;

namespace AyutthayaSimulator.UI
{
    public sealed class SettingsUiModel : MonoBehaviour
    {
        [SerializeField] private LocalizationPreferenceService localization;
        public void SetThai() => localization?.SetLanguage(UiLanguage.Thai);
        public void SetEnglish() => localization?.SetLanguage(UiLanguage.English);
        public void SetQuality(int quality) { if (quality >= 0 && quality < QualitySettings.names.Length) QualitySettings.SetQualityLevel(quality, true); }
    }
}
