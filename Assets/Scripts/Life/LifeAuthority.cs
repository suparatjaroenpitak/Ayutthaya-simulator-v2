using UnityEngine;

namespace AyutthayaSimulator.Life
{
    public interface ILifeAuthority { bool CanApply(GameObject actor, string actionId, float amount); }
    public sealed class ServerLifeAuthority : MonoBehaviour, ILifeAuthority
    {
        [SerializeField] private bool serverMode = true;
        [SerializeField] private float maxActionAmount = 100f;
        public bool CanApply(GameObject actor, string actionId, float amount) => serverMode && actor != null && !string.IsNullOrWhiteSpace(actionId) && amount >= 0f && amount <= maxActionAmount;
    }
}
