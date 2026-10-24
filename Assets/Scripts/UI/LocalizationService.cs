using System;
using System.Collections.Generic;
using UnityEngine;
using AyutthayaSimulator.Persistence;

namespace AyutthayaSimulator.UI
{
    public enum UiLanguage { Thai, English }
    [Serializable] public struct TranslationRow { public string key; [TextArea] public string thai; [TextArea] public string english; }
    [CreateAssetMenu(menuName = "Ayutthaya/UI/Translation Table", fileName = "TranslationTable")]
    public sealed class TranslationTable : ScriptableObject
    {
        public TranslationRow[] rows = Array.Empty<TranslationRow>();
        public bool TryGet(string key, UiLanguage language, out string value) { for (int i = 0; i < rows.Length; i++) if (rows[i].key == key) { value = language == UiLanguage.Thai ? rows[i].thai : rows[i].english; return !string.IsNullOrEmpty(value); } value = key; return false; }
    }
    public sealed class LocalizationPreferenceService : MonoBehaviour
    {
        [SerializeField] private TranslationTable table;
        [SerializeField] private UiLanguage language = UiLanguage.Thai;
        private const string PreferenceKey = "ayutthaya.ui.language";
        public UiLanguage Language => language;
        public event Action<UiLanguage> LanguageChanged;
        private void Awake() { language = (UiLanguage)PlayerPrefs.GetInt(PreferenceKey, (int)language); }
        public void SetLanguage(UiLanguage value) { language = value; PlayerPrefs.SetInt(PreferenceKey, (int)value); PlayerPrefs.Save(); LanguageChanged?.Invoke(value); }
        public string Get(string key) { return table != null && table.TryGet(key, language, out string value) ? value : key; }
        public string GetPlural(string key, int count) { string value = Get(key); return value.Replace("{count}", count.ToString()); }
    }
}
