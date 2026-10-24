using UnityEngine;

namespace AyutthayaSimulator.Animation
{
    public enum InteractionPointType { Generic, Sit, Sleep, Farm, Work }

    public sealed class InteractionPoint : MonoBehaviour
    {
        [SerializeField] private InteractionPointType type;
        [SerializeField] private Transform alignment;
        [SerializeField] private float useRadius = 1.25f;
        public InteractionPointType Type => type;
        public Transform Alignment => alignment == null ? transform : alignment;
        public bool IsInRange(Vector3 position) => Vector3.Distance(position, Alignment.position) <= useRadius;

        public void Align(Transform actor)
        {
            if (actor == null || !IsInRange(actor.position)) return;
            actor.SetPositionAndRotation(Alignment.position, Alignment.rotation);
        }
    }
}
