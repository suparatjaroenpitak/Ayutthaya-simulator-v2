using System.Collections.Generic;
using UnityEngine;

namespace AyutthayaSimulator.Property
{
    public sealed class PropertyRegistry : MonoBehaviour, IPropertyAuthority
    {
        [SerializeField] private PropertyDefinition[] definitions = new PropertyDefinition[0];
        [SerializeField] private PropertyState[] initialStates = new PropertyState[0];
        private readonly Dictionary<string, PropertyState> states = new Dictionary<string, PropertyState>();
        private void Awake() { for (int i = 0; i < initialStates.Length; i++) if (initialStates[i] != null && !string.IsNullOrWhiteSpace(initialStates[i].propertyId)) states[initialStates[i].propertyId] = initialStates[i]; }
        public PropertyDefinition FindDefinition(string id) { for (int i = 0; i < definitions.Length; i++) if (definitions[i] != null && definitions[i].propertyId == id) return definitions[i]; return null; }
        public PropertyState GetOrCreate(string id) { if (!states.TryGetValue(id, out PropertyState state)) { state = new PropertyState { propertyId = id }; states[id] = state; } return state; }
        public bool IsOwner(string actorId, string propertyId) => !string.IsNullOrWhiteSpace(actorId) && GetOrCreate(propertyId).ownerId == actorId;
        public bool CanChange(string actorId, string propertyId) => IsOwner(actorId, propertyId);
        public bool TryPurchase(string actorId, string propertyId, long priceSatang, long availableFunds)
        {
            PropertyDefinition definition = FindDefinition(propertyId); PropertyState state = GetOrCreate(propertyId);
            if (definition == null || state.purchased || !definition.canPurchase || priceSatang != definition.purchasePriceSatang || availableFunds < priceSatang || string.IsNullOrWhiteSpace(actorId)) return false;
            state.ownerId = actorId; state.purchased = true; state.rented = false; state.tenantId = string.Empty; return true;
        }
        public bool TryRent(string actorId, string propertyId, long priceSatang)
        {
            PropertyDefinition definition = FindDefinition(propertyId); PropertyState state = GetOrCreate(propertyId);
            if (definition == null || state.purchased || state.rented || !definition.canRent || priceSatang != definition.rentPriceSatang || string.IsNullOrWhiteSpace(actorId)) return false;
            state.tenantId = actorId; state.rented = true; return true;
        }
        public void RollbackPurchase(string propertyId) { PropertyState state = GetOrCreate(propertyId); state.ownerId = string.Empty; state.purchased = false; }
        public void RollbackRent(string propertyId) { PropertyState state = GetOrCreate(propertyId); state.tenantId = string.Empty; state.rented = false; }
    }
}
