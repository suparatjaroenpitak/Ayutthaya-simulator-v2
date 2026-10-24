using UnityEngine;

namespace AyutthayaSimulator.Economy
{
    public sealed class Shop : MonoBehaviour
    {
        [SerializeField] private PriceBook prices;
        [SerializeField] private EconomyLedger ledger;
        [SerializeField] private Inventory stock;
        public bool TryPurchase(GameObject actor, string actorId, Wallet wallet, Inventory buyer, string productId, int quantity)
        {
            if (actor == null || wallet == null || buyer == null || prices == null || stock == null || ledger == null || quantity <= 0 || !prices.TryGet(productId, out PriceEntry price)) return false;
            long total = checked(price.buyPriceSatang * quantity);
            if (stock.Count(productId) < quantity || !buyer.TryAdd(productId, quantity)) return false;
            if (!ledger.TryCommit(actorId, EconomyTransactionType.Purchase, total, $"purchase:{actorId}:{productId}:{Time.frameCount}", wallet, null)) { buyer.TryRemove(productId, quantity); return false; }
            stock.TryRemove(productId, quantity); return true;
        }
        public bool TrySell(GameObject actor, string actorId, Wallet wallet, Inventory seller, string productId, int quantity)
        {
            if (actor == null || wallet == null || seller == null || prices == null || ledger == null || quantity <= 0 || !prices.TryGet(productId, out PriceEntry price) || !seller.TryRemove(productId, quantity)) return false;
            long total = checked(price.sellPriceSatang * quantity);
            if (!ledger.TryCommit(actorId, EconomyTransactionType.Sale, total, $"sale:{actorId}:{productId}:{Time.frameCount}", null, wallet)) { seller.TryAdd(productId, quantity); return false; }
            return true;
        }
    }
}
