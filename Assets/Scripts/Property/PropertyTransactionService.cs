using UnityEngine;
using AyutthayaSimulator.Economy;

namespace AyutthayaSimulator.Property
{
    public sealed class PropertyTransactionService : MonoBehaviour
    {
        [SerializeField] private PropertyRegistry registry;
        [SerializeField] private EconomyLedger ledger;
        public bool TryPurchase(string actorId, string propertyId, Wallet wallet)
        {
            PropertyDefinition definition = registry == null ? null : registry.FindDefinition(propertyId);
            if (definition == null || wallet == null || ledger == null || !registry.TryPurchase(actorId, propertyId, definition.purchasePriceSatang, wallet.BalanceSatang)) return false;
            if (!ledger.TryCommit(actorId, EconomyTransactionType.Purchase, definition.purchasePriceSatang, "property:purchase:" + propertyId + ":" + actorId, wallet, null, propertyId)) { registry.RollbackPurchase(propertyId); return false; }
            return true;
        }
        public bool TryRent(string actorId, string propertyId, Wallet wallet)
        {
            PropertyDefinition definition = registry == null ? null : registry.FindDefinition(propertyId);
            if (definition == null || wallet == null || ledger == null || wallet.BalanceSatang < definition.rentPriceSatang || !registry.TryRent(actorId, propertyId, definition.rentPriceSatang)) return false;
            if (!ledger.TryCommit(actorId, EconomyTransactionType.Purchase, definition.rentPriceSatang, "property:rent:" + propertyId + ":" + actorId, wallet, null, propertyId)) { registry.RollbackRent(propertyId); return false; }
            return true;
        }
    }
}
