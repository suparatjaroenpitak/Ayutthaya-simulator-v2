using System;
using System.Collections.Generic;
using UnityEngine;

namespace AyutthayaSimulator.Economy
{
    public enum EconomyTransactionType { Purchase, Sale, Wage, DeliveryReward, FarmIncome, RepairIncome, BankTransfer }

    [Serializable]
    public struct EconomyAuditEntry
    {
        public string transactionId;
        public string actorId;
        public EconomyTransactionType type;
        public long amountSatang;
        public string rewardId;
        public string createdAtUtc;
    }

    public interface IEconomyAuthority { bool Validate(string actorId, EconomyTransactionType type, long amountSatang, string idempotencyKey); }

    public sealed class EconomyLedger : MonoBehaviour, IEconomyAuthority
    {
        [SerializeField] private bool serverMode = true;
        [SerializeField] private long maxTransactionSatang = 100000000;
        private readonly HashSet<string> committedKeys = new HashSet<string>();
        private readonly List<EconomyAuditEntry> audit = new List<EconomyAuditEntry>();
        public IReadOnlyList<EconomyAuditEntry> Audit => audit;
        public bool Validate(string actorId, EconomyTransactionType type, long amountSatang, string idempotencyKey) => serverMode && !string.IsNullOrWhiteSpace(actorId) && amountSatang >= 0 && amountSatang <= maxTransactionSatang && !string.IsNullOrWhiteSpace(idempotencyKey) && !committedKeys.Contains(idempotencyKey);
        public bool TryCommit(string actorId, EconomyTransactionType type, long amountSatang, string idempotencyKey, IAccount debit, IAccount credit, string rewardId = "")
        {
            if (!Validate(actorId, type, amountSatang, idempotencyKey)) return false;
            if (debit != null && !debit.TryDebit(amountSatang)) return false;
            if (credit != null && !credit.TryCredit(amountSatang)) { debit?.TryCredit(amountSatang); return false; }
            committedKeys.Add(idempotencyKey);
            audit.Add(new EconomyAuditEntry { transactionId = Guid.NewGuid().ToString("N"), actorId = actorId, type = type, amountSatang = amountSatang, rewardId = rewardId, createdAtUtc = DateTime.UtcNow.ToString("O") });
            return true;
        }
        public bool HasCommitted(string key) => committedKeys.Contains(key);
    }
}
