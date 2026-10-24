using UnityEngine;

namespace AyutthayaSimulator.Farming
{
    public sealed class SeasonCalendar : MonoBehaviour
    {
        [SerializeField] private int daysPerSeason = 30;
        [SerializeField] private int startDay = 1;
        public int Day { get; private set; }
        public Season CurrentSeason => (Season)(((Day - 1) / Mathf.Max(1, daysPerSeason)) % 3);
        private void Awake() => Day = Mathf.Max(1, startDay);
        public void AdvanceDay(int days = 1) => Day = Mathf.Max(1, Day + days);
        public bool IsSuitable(CropDefinition crop) { if (crop == null) return false; for (int i = 0; i < crop.suitableSeasons.Length; i++) if (crop.suitableSeasons[i] == CurrentSeason) return true; return false; }
    }
}
