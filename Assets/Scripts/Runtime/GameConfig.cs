using UnityEngine;

namespace AyutthayaSimulator.Runtime
{
    [CreateAssetMenu(menuName = "Ayutthaya/Config/Game Config", fileName = "GameConfig")]
    public sealed class GameConfig : ScriptableObject
    {
        [Header("Identity")]
        public string gameVersion = "0.2.0-phase02";
        public string defaultSaveSlot = "slot_01";

        [Header("Player")]
        [Min(0.1f)] public float walkSpeed = 4.5f;
        [Min(0.1f)] public float runSpeed = 7f;
        [Min(0.1f)] public float rotationSharpness = 12f;
        [Min(0.1f)] public float gravity = 25f;
        [Min(0.1f)] public float jumpHeight = 1.4f;
        [Min(0.01f)] public float groundedStickForce = 2f;
        [Min(0.01f)] public float groundProbeDistance = 0.35f;
        [Min(0.01f)] public float spawnProbeHeight = 3f;
        [Min(0.01f)] public float spawnProbeDistance = 20f;

        [Header("Camera")]
        [Min(0.1f)] public float cameraDistance = 5f;
        public float cameraMinPitch = -35f;
        public float cameraMaxPitch = 70f;
        [Min(0.01f)] public float cameraCollisionRadius = 0.2f;
        [Min(0.01f)] public float cameraCollisionBuffer = 0.15f;

        [Header("Needs")]
        [Min(1f)] public float maxHunger = 100f;
        [Min(1f)] public float maxEnergy = 100f;
        [Min(0f)] public float hungerDrainPerMinute = 2f;
        [Min(0f)] public float energyDrainPerMinute = 1f;
    }
}
