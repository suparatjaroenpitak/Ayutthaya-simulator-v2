using UnityEngine;

namespace AyutthayaSimulator.Runtime
{
    public sealed class GameBootstrap : MonoBehaviour
    {
        [SerializeField] private GameConfig config;
        [SerializeField] private ThirdPersonPlayer player;
        [SerializeField] private PlayerNeeds playerNeeds;

        private void Awake()
        {
            if (config == null || player == null || playerNeeds == null)
            {
                Debug.LogError("GameBootstrap is not fully configured.", this);
                enabled = false;
                return;
            }
            playerNeeds.Initialize(config);
            if (SaveService.TryLoad(config.defaultSaveSlot, out SaveData data))
            {
                player.transform.position = data.playerPosition;
                playerNeeds.Restore(data.hunger, data.energy);
            }
        }

        private void OnApplicationPause(bool paused) { if (paused) Save(); }
        private void OnApplicationQuit() => Save();

        public void Save()
        {
            if (config == null || player == null || playerNeeds == null) return;
            SaveService.Save(new SaveData
            {
                slotId = config.defaultSaveSlot,
                playerPosition = player.transform.position,
                hunger = playerNeeds.Hunger,
                energy = playerNeeds.Energy,
                money = 0
            });
        }
    }
}
