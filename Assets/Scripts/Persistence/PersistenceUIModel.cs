using UnityEngine;

namespace AyutthayaSimulator.Persistence
{
    public sealed class PersistenceUIModel : MonoBehaviour
    {
        public event System.Action<PersistenceResult> ResultChanged;
        public void Publish(PersistenceResult result) => ResultChanged?.Invoke(result);
    }
}
