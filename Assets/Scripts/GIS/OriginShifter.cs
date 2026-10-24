using UnityEngine;

namespace AyutthayaSimulator.GIS
{
    public sealed class OriginShifter : MonoBehaviour
    {
        [SerializeField] private Transform player;
        [SerializeField] private Transform worldRoot;
        [SerializeField] private float shiftDistance = 2000f;
        public Vector3 WorldOffset { get; private set; }

        private void LateUpdate()
        {
            if (player == null || worldRoot == null || player.position.sqrMagnitude < shiftDistance * shiftDistance) return;
            Vector3 offset = new Vector3(player.position.x, 0f, player.position.z);
            worldRoot.position -= offset;
            player.position -= offset;
            WorldOffset += offset;
        }
    }
}
