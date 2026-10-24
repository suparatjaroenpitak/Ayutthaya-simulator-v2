using UnityEngine;
using AyutthayaSimulator.Animation;

namespace AyutthayaSimulator.Farming
{
    public sealed class FarmInteraction : MonoBehaviour
    {
        [SerializeField] private FarmPlot plot;
        [SerializeField] private InteractionPoint point;
        [SerializeField] private Animator animator;
        public bool Prepare(GameObject actor) { if (!CanUse(actor)) return false; point.Align(actor.transform); animator?.SetTrigger("Interact"); return plot.PrepareSoil(); }
        public bool Harvest(GameObject actor, FarmStorage storage) { if (!CanUse(actor) || storage == null || !plot.TryHarvest(out HarvestedProduce produce)) return false; point.Align(actor.transform); animator?.SetTrigger("Interact"); return storage.TryStore(produce); }
        private bool CanUse(GameObject actor) => actor != null && plot != null && point != null && point.IsInRange(actor.transform.position);
    }
}
