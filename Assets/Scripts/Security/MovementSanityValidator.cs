using System.Collections.Generic;
using UnityEngine;

namespace AyutthayaSimulator.Server
{
    public sealed class MovementSanityValidator : MonoBehaviour
    {
        [SerializeField] private float maxSpeed = 12f;
        [SerializeField] private float positionTolerance = 4f;
        [SerializeField] private float maxVerticalDelta = 8f;
        private readonly Dictionary<string, Vector3> lastPositions = new Dictionary<string, Vector3>();
        public bool Accept(string accountId, Vector3 claimedPosition, float deltaTime)
        {
            if (string.IsNullOrWhiteSpace(accountId) || deltaTime <= 0f || deltaTime > 1f) return false;
            if (!lastPositions.TryGetValue(accountId, out Vector3 last)) { lastPositions[accountId] = claimedPosition; return true; }
            Vector3 delta = claimedPosition - last; float horizontal = new Vector2(delta.x, delta.z).magnitude;
            bool valid = horizontal <= maxSpeed * deltaTime + positionTolerance && Mathf.Abs(delta.y) <= maxVerticalDelta;
            if (valid) lastPositions[accountId] = claimedPosition;
            return valid;
        }
        public void Remove(string accountId) => lastPositions.Remove(accountId);
    }
}
