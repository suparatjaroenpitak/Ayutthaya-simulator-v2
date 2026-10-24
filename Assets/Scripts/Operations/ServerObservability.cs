using System.Collections.Generic;
using UnityEngine;

namespace AyutthayaSimulator.Operations
{
    public sealed class ServerObservability : MonoBehaviour
    {
        private readonly Dictionary<string, long> counters = new Dictionary<string, long>();
        public void Increment(string name, long amount = 1) { if (!counters.ContainsKey(name)) counters[name] = 0; counters[name] += amount; }
        public long Get(string name) => counters.TryGetValue(name, out long value) ? value : 0;
        public IReadOnlyDictionary<string, long> Snapshot() => new Dictionary<string, long>(counters);
        public void RecordRejectedRequest(string reason) { Increment("requests.rejected"); Increment("requests.rejected." + reason); }
    }
}
