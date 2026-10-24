using System;
using System.Collections.Generic;
using UnityEngine;

namespace AyutthayaSimulator.Property
{
    [Serializable] public struct DecorationState { public string decorationId; public Vector3 position; public Quaternion rotation; public string prefabKey; }
    public sealed class FurniturePlacement : MonoBehaviour
    {
        [SerializeField] private PropertyRegistry registry;
        [SerializeField] private string propertyId;
        [SerializeField] private Transform placementRoot;
        private readonly Dictionary<string, GameObject> visuals = new Dictionary<string, GameObject>();
        public bool TryPlace(string actorId, DecorationState state, GameObject visualPrefab)
        {
            if (registry == null || !registry.CanChange(actorId, propertyId) || string.IsNullOrWhiteSpace(state.decorationId) || visualPrefab == null) return false;
            if (visuals.ContainsKey(state.decorationId)) return false;
            GameObject visual = Instantiate(visualPrefab, state.position, state.rotation, placementRoot); visuals[state.decorationId] = visual;
            PropertyState property = registry.GetOrCreate(propertyId); List<string> ids = new List<string>(property.decorationIds); ids.Add(state.decorationId); property.decorationIds = ids.ToArray(); return true;
        }
        public bool TryRemove(string actorId, string decorationId)
        {
            if (registry == null || !registry.CanChange(actorId, propertyId) || !visuals.TryGetValue(decorationId, out GameObject visual)) return false;
            Destroy(visual); visuals.Remove(decorationId); return true;
        }
    }
}
