using UnityEngine;

namespace AyutthayaSimulator.Runtime
{
    public interface IInteractable
    {
        void Interact(GameObject interactor);
    }

    public sealed class PlayerInteraction : MonoBehaviour
    {
        [SerializeField] private Camera playerCamera;
        [SerializeField] private float interactionDistance = 3f;
        [SerializeField] private LayerMask interactionMask = Physics.DefaultRaycastLayers;

        public bool TryInteract()
        {
            if (playerCamera == null) return false;
            Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f));
            if (!Physics.Raycast(ray, out RaycastHit hit, interactionDistance, interactionMask, QueryTriggerInteraction.Ignore)) return false;
            IInteractable interactable = null;
            MonoBehaviour[] behaviours = hit.collider.GetComponentsInParent<MonoBehaviour>(true);
            for (int i = 0; i < behaviours.Length; i++)
            {
                if (behaviours[i] is IInteractable candidate)
                {
                    interactable = candidate;
                    break;
                }
            }
            if (interactable == null) return false;
            interactable.Interact(gameObject);
            return true;
        }
    }
}
