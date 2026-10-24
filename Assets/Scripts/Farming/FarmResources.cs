using System.Collections.Generic;
using UnityEngine;

namespace AyutthayaSimulator.Farming
{
    public sealed class FarmStorage : MonoBehaviour
    {
        [SerializeField] private float capacityKg = 5000f;
        private readonly Dictionary<string, float> amounts = new Dictionary<string, float>();
        public float UsedKg { get; private set; }
        public bool TryStore(HarvestedProduce produce) { if (produce.kilograms <= 0f || UsedKg + produce.kilograms > capacityKg) return false; amounts[produce.cropId] = Get(produce.cropId) + produce.kilograms; UsedKg += produce.kilograms; return true; }
        public float Get(string cropId) => amounts.TryGetValue(cropId, out float amount) ? amount : 0f;
        public bool TryRemove(string cropId, float kilograms) { if (kilograms <= 0f || Get(cropId) < kilograms) return false; amounts[cropId] -= kilograms; UsedKg -= kilograms; return true; }
    }

    public interface IFarmTransactionAuthority { bool CanTransact(GameObject actor); }

    public sealed class FarmMarket : MonoBehaviour, IFarmTransactionAuthority
    {
        [SerializeField] private FarmStorage storage;
        [SerializeField] private int pricePerKg = 12;
        [SerializeField] private bool serverAuthority = true;
        public int LastSaleValue { get; private set; }
        public bool CanTransact(GameObject actor) => serverAuthority || actor != null;
        public bool TrySell(GameObject actor, string cropId, float kilograms, out int value)
        {
            value = 0; if (!CanTransact(actor) || storage == null || !storage.TryRemove(cropId, kilograms)) return false;
            value = Mathf.RoundToInt(kilograms * pricePerKg); LastSaleValue = value; return true;
        }
    }
}
