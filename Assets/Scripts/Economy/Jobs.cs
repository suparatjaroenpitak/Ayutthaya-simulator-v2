using System;
using System.Collections.Generic;
using UnityEngine;

namespace AyutthayaSimulator.Economy
{
    public enum JobType { Civilian, Delivery, Farming, Repair }
    [CreateAssetMenu(menuName = "Ayutthaya/Economy/Job Definition", fileName = "JobDefinition")]
    public sealed class JobDefinition : ScriptableObject
    {
        public string jobId; public string titleThai; public string titleEnglish; public JobType type; [Min(0)] public long wageSatang; [Min(0)] public int experience;
        public bool legal = true;
    }
    public sealed class JobProgression : MonoBehaviour
    {
        [Serializable] public struct JobLevel { public string jobId; public int level; public int experience; }
        [SerializeField] private JobLevel[] levels = Array.Empty<JobLevel>();
        public int GetLevel(string jobId) { for (int i = 0; i < levels.Length; i++) if (levels[i].jobId == jobId) return Mathf.Max(1, levels[i].level); return 1; }
        public void AddExperience(string jobId, int amount) { for (int i = 0; i < levels.Length; i++) if (levels[i].jobId == jobId) { levels[i].experience += Mathf.Max(0, amount); levels[i].level = 1 + levels[i].experience / 1000; return; } Array.Resize(ref levels, levels.Length + 1); levels[levels.Length - 1] = new JobLevel { jobId = jobId, level = 1 + Mathf.Max(0, amount) / 1000, experience = Mathf.Max(0, amount) }; }
    }
    public sealed class JobPayoutService : MonoBehaviour
    {
        [SerializeField] private EconomyLedger ledger;
        public bool TryPay(string actorId, JobDefinition job, Wallet wallet, string rewardId, JobProgression progression)
        {
            if (job == null || !job.legal || wallet == null || ledger == null || string.IsNullOrWhiteSpace(rewardId)) return false;
            bool paid = ledger.TryCommit(actorId, job.type == JobType.Delivery ? EconomyTransactionType.DeliveryReward : job.type == JobType.Farming ? EconomyTransactionType.FarmIncome : job.type == JobType.Repair ? EconomyTransactionType.RepairIncome : EconomyTransactionType.Wage, job.wageSatang, "reward:" + rewardId, null, wallet, rewardId);
            if (paid) progression?.AddExperience(job.jobId, job.experience);
            return paid;
        }
    }
}
