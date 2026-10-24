using UnityEngine;

namespace AyutthayaSimulator.Property
{
    public readonly struct PropertyUIState { public readonly string propertyId, ownerId, tenantId; public readonly bool purchased, rented; public PropertyUIState(PropertyState state) { propertyId = state.propertyId; ownerId = state.ownerId; tenantId = state.tenantId; purchased = state.purchased; rented = state.rented; } }
    public sealed class PropertyUIModel : MonoBehaviour
    {
        [SerializeField] private PropertyRegistry registry;
        public PropertyUIState Snapshot(string propertyId) => new PropertyUIState(registry == null ? new PropertyState { propertyId = propertyId } : registry.GetOrCreate(propertyId));
    }
}
