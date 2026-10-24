using UnityEngine;

namespace AyutthayaSimulator.UI
{
    public readonly struct GameHudSnapshot
    {
        public readonly float hunger, energy, stamina, health; public readonly long walletSatang; public readonly int questCount; public readonly string vehicleLabel;
        public GameHudSnapshot(float h, float e, float s, float hp, long wallet, int quests, string vehicle) { hunger = h; energy = e; stamina = s; health = hp; walletSatang = wallet; questCount = quests; vehicleLabel = vehicle; }
    }
    public sealed class GameHudModel : MonoBehaviour
    {
        public event System.Action<GameHudSnapshot> Changed;
        public void Publish(GameHudSnapshot snapshot) => Changed?.Invoke(snapshot);
    }
}
