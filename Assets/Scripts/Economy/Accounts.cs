using UnityEngine;

namespace AyutthayaSimulator.Economy
{
    public interface IAccount
    {
        long BalanceSatang { get; }
        bool TryCredit(long amount);
        bool TryDebit(long amount);
    }

    public sealed class Wallet : MonoBehaviour, IAccount
    {
        [SerializeField] private long balanceSatang;
        public long BalanceSatang => balanceSatang;
        public bool TryCredit(long amount) { if (amount < 0 || balanceSatang > long.MaxValue - amount) return false; balanceSatang += amount; return true; }
        public bool TryDebit(long amount) { if (amount < 0 || amount > balanceSatang) return false; balanceSatang -= amount; return true; }
    }

    public sealed class BankAccount : MonoBehaviour, IAccount
    {
        [SerializeField] private long balanceSatang;
        public long BalanceSatang => balanceSatang;
        public bool TryCredit(long amount) { if (amount < 0 || balanceSatang > long.MaxValue - amount) return false; balanceSatang += amount; return true; }
        public bool TryDebit(long amount) { if (amount < 0 || amount > balanceSatang) return false; balanceSatang -= amount; return true; }
    }
}
