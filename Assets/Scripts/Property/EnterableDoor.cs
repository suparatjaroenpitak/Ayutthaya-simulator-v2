using UnityEngine;

namespace AyutthayaSimulator.Property
{
    public sealed class EnterableDoor : MonoBehaviour
    {
        [SerializeField] private string propertyId;
        [SerializeField] private PropertyRegistry registry;
        [SerializeField] private InteriorStreamer interiors;
        [SerializeField] private Transform entryPoint;
        [SerializeField] private bool open;
        public bool TryEnter(GameObject actor, string actorId)
        {
            if (actor == null || registry == null || !registry.IsOwner(actorId, propertyId) && registry.GetOrCreate(propertyId).tenantId != actorId) return false;
            if (entryPoint != null) actor.transform.SetPositionAndRotation(entryPoint.position, entryPoint.rotation);
            open = true; interiors?.Load(propertyId); return true;
        }
        public void Exit(GameObject actor) { if (actor == null) return; open = false; interiors?.Unload(propertyId); }
    }
}
