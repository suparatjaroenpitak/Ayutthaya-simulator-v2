using UnityEngine;

namespace AyutthayaSimulator.Farming
{
    public enum FarmWeather { Clear, Cloudy, Rain, Storm, Drought }

    public sealed class FarmWeatherService : MonoBehaviour
    {
        [SerializeField] private FarmWeather current = FarmWeather.Clear;
        [Range(0f, 1f)] [SerializeField] private float irrigationFromRain = 0.25f;
        public FarmWeather Current => current;
        public float GrowthMultiplier => current == FarmWeather.Storm ? 0.75f : current == FarmWeather.Drought ? 0.35f : 1f;
        public float IrrigationAmount => current == FarmWeather.Rain ? irrigationFromRain : current == FarmWeather.Storm ? irrigationFromRain * 2f : 0f;
        public void SetWeather(FarmWeather weather) => current = weather;
    }
}
