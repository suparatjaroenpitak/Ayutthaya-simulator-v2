using UnityEngine;

namespace AyutthayaSimulator.Runtime
{
    public static class Grounding
    {
        public static bool IsGrounded(Transform root, CharacterController controller, float probeDistance)
        {
            if (root == null || controller == null) return false;
            Vector3 origin = root.position + Vector3.up * 0.05f;
            float radius = Mathf.Max(0.01f, controller.radius * 0.9f);
            return Physics.SphereCast(origin, radius, Vector3.down, out _, probeDistance + 0.05f, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore);
        }

        public static bool TryFindSpawn(Vector3 requested, float probeHeight, float probeDistance, out Vector3 safePosition)
        {
            Vector3 origin = requested + Vector3.up * probeHeight;
            if (Physics.Raycast(origin, Vector3.down, out RaycastHit hit, probeDistance + probeHeight, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore))
            {
                safePosition = hit.point;
                return true;
            }
            safePosition = requested;
            return false;
        }
    }
}
