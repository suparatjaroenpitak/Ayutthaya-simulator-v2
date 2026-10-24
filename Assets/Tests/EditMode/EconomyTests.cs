using NUnit.Framework;
using UnityEngine;
using AyutthayaSimulator.Economy;

public sealed class EconomyTests
{
    [Test] public void ThaiBaht_ConvertsToSatangExactly() { Assert.AreEqual(12345, ThaiBaht.FromBaht(123.45m).Satang); }
    [Test] public void Ledger_RejectsDuplicateIdempotencyKey()
    {
        GameObject go = new GameObject("Ledger"); EconomyLedger ledger = go.AddComponent<EconomyLedger>(); GameObject walletObject = new GameObject("Wallet"); Wallet wallet = walletObject.AddComponent<Wallet>();
        Assert.IsTrue(ledger.TryCommit("somchai", EconomyTransactionType.Wage, 1000, "reward:one", null, wallet, "one")); Assert.IsFalse(ledger.TryCommit("somchai", EconomyTransactionType.Wage, 1000, "reward:one", null, wallet, "one")); Assert.AreEqual(1000, wallet.BalanceSatang); Object.DestroyImmediate(go); Object.DestroyImmediate(walletObject);
    }
    [Test] public void Wallet_RejectsOverspend() { GameObject go = new GameObject("Wallet"); Wallet wallet = go.AddComponent<Wallet>(); Assert.IsFalse(wallet.TryDebit(1)); Object.DestroyImmediate(go); }
}
