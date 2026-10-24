using UnityEngine;

namespace AyutthayaSimulator.Economy
{
    public readonly struct EconomyUIState { public readonly long walletSatang, bankSatang; public EconomyUIState(long w, long b) { walletSatang = w; bankSatang = b; } }
    public sealed class EconomyUIModel : MonoBehaviour
    {
        [SerializeField] private Wallet wallet; [SerializeField] private BankAccount bank;
        public event System.Action<EconomyUIState> Changed;
        public EconomyUIState Snapshot() => new EconomyUIState(wallet == null ? 0 : wallet.BalanceSatang, bank == null ? 0 : bank.BalanceSatang);
        public void NotifyChanged() => Changed?.Invoke(Snapshot());
    }
}
