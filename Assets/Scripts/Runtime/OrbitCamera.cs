using UnityEngine;
using UnityEngine.InputSystem;

namespace AyutthayaSimulator.Runtime
{
    public sealed class OrbitCamera : MonoBehaviour
    {
        [SerializeField] private GameConfig config;
        [SerializeField] private Transform target;
        [SerializeField] private InputActionReference lookAction;
        [SerializeField] private LayerMask collisionMask = Physics.DefaultRaycastLayers;
        [SerializeField] private float lookSensitivity = 0.08f;
        [SerializeField] private float followSharpness = 14f;
        [SerializeField] private float initialPitch = 18f;
        [SerializeField] private float initialYaw = 0f;
        private float yaw;
        private float pitch;

        private void Awake() { yaw = initialYaw; pitch = initialPitch; }
        private void OnEnable() => lookAction?.action.Enable();
        private void OnDisable() => lookAction?.action.Disable();

        private void LateUpdate()
        {
            if (config == null || target == null) return;
            Vector2 look = lookAction == null ? Vector2.zero : lookAction.action.ReadValue<Vector2>();
            yaw += look.x * lookSensitivity;
            pitch = Mathf.Clamp(pitch - look.y * lookSensitivity, config.cameraMinPitch, config.cameraMaxPitch);
            Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
            Vector3 pivot = target.position + Vector3.up * 1.55f;
            Vector3 desired = pivot - rotation * Vector3.forward * config.cameraDistance;
            Vector3 offset = desired - pivot;
            float distance = offset.magnitude;
            if (Physics.SphereCast(pivot, config.cameraCollisionRadius, offset.normalized, out RaycastHit hit, distance, collisionMask, QueryTriggerInteraction.Ignore))
                desired = pivot + offset.normalized * Mathf.Max(0.05f, hit.distance - config.cameraCollisionBuffer);
            transform.position = Vector3.Lerp(transform.position, desired, 1f - Mathf.Exp(-followSharpness * Time.deltaTime));
            transform.rotation = rotation;
        }
    }
}
