using System;
using UnityEngine;

namespace AyutthayaSimulator.Property
{
    [Serializable]
    public sealed class PropertyState
    {
        public string propertyId;
        public string ownerId;
        public string tenantId;
        public bool rented;
        public bool purchased;
        public string[] decorationIds = Array.Empty<string>();
    }

    public interface IPropertyAuthority
    {
        bool IsOwner(string actorId, string propertyId);
        bool CanChange(string actorId, string propertyId);
    }
}
