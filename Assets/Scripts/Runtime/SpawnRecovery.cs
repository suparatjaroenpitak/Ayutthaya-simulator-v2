using UnityEngine;

namespace AyutthayaSimulator.Runtime
{
    public sealed class SpawnRecovery : MonoBehaviour
    {
        [SerializeField] private GameConfig config;
        [SerializeField] private Transform fallbackSpawn;
        [SerializeField] private float minimumY = -20f;
        [SerializeField] private float checkInterval = 0.25f;
        private float nextCheck;

        private void Update()
        {
            if (config == null || Time.time < nextCheck) return;
            nextCheck = Time.time + checkInterval;
            if (transform.position.y > minimumY && Grounding.IsGrounded(transform, GetComponent<CharacterController>(), config.groundProbeDistance)) return;
            Recover();
        }

        public void Recover()
        {
            Vector3 requested = fallbackSpawn == null ? Vector3.zero : fallbackSpawn.position;
            if (!Grounding.TryFindSpawn(requested, config.spawnProbeHeight, config.spawnProbeDistance, out Vector3 safe)) safe = requested;
            CharacterController controller = GetComponent<CharacterController>();
            if (controller != null) controller.enabled = false;
            transform.SetPositionAndRotation(safe, fallbackSpawn == null ? transform.rotation : fallbackSpawn.rotation);
            if (controller != null) controller.enabled = true;
        }
    }
}
