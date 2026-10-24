using UnityEngine;

namespace AyutthayaSimulator.Life
{
    public interface IWeatherProvider { string CurrentWeatherId { get; } float EnergyModifier { get; } }
    public sealed class LifeClock : MonoBehaviour
    {
        [SerializeField] private float gameMinutesPerRealSecond = 1f;
        [SerializeField] private int startMinute = 420;
        public int MinuteOfDay { get; private set; }
        public int Day { get; private set; } = 1;
        public int Hour => MinuteOfDay / 60;
        public event System.Action<int, int> TimeChanged;
        private float accumulator;
        private void Awake() => MinuteOfDay = Mathf.Clamp(startMinute, 0, 1439);
        private void Update()
        {
            accumulator += Time.deltaTime * gameMinutesPerRealSecond;
            int advance = Mathf.FloorToInt(accumulator); if (advance <= 0) return;
            accumulator -= advance; MinuteOfDay += advance;
            while (MinuteOfDay >= 1440) { MinuteOfDay -= 1440; Day++; }
            TimeChanged?.Invoke(Day, MinuteOfDay);
        }
        public void SetTime(int day, int minute) { Day = Mathf.Max(1, day); MinuteOfDay = Mathf.Clamp(minute, 0, 1439); TimeChanged?.Invoke(Day, MinuteOfDay); }
    }

    public sealed class DefaultWeatherProvider : MonoBehaviour, IWeatherProvider
    {
        [SerializeField] private string weatherId = "clear";
        [SerializeField] private float energyModifier = 1f;
        public string CurrentWeatherId => weatherId;
        public float EnergyModifier => energyModifier;
        public void SetWeather(string id, float modifier) { weatherId = id; energyModifier = Mathf.Clamp(modifier, 0.5f, 1.5f); }
    }
}
