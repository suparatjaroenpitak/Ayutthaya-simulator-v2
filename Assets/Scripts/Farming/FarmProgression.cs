using UnityEngine;

namespace AyutthayaSimulator.Farming
{
    public sealed class FarmProgression : MonoBehaviour
    {
        [SerializeField] private int startingLevel = 1;
        public int Level { get; private set; }
        public int Experience { get; private set; }
        private void Awake() => Level = Mathf.Max(1, startingLevel);
        public void AddExperience(int amount) { Experience = Mathf.Max(0, Experience + Mathf.Max(0, amount)); Level = 1 + Experience / 1000; }
    }
}
