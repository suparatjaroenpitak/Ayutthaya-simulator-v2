using System.Collections.Generic;
using UnityEngine;

namespace AyutthayaSimulator.Security
{
    public sealed class TokenBucketRateLimiter
    {
        private sealed class Bucket { public float tokens; public float last; }
        private readonly Dictionary<string, Bucket> buckets = new Dictionary<string, Bucket>();
        private readonly float capacity, refillPerSecond;
        public TokenBucketRateLimiter(float capacity, float refillPerSecond) { this.capacity = Mathf.Max(1f, capacity); this.refillPerSecond = Mathf.Max(0.01f, refillPerSecond); }
        public bool TryConsume(string key, float cost = 1f, float now = -1f)
        {
            if (string.IsNullOrWhiteSpace(key) || cost <= 0f) return false;
            if (!buckets.TryGetValue(key, out Bucket bucket)) { bucket = new Bucket { tokens = capacity, last = now < 0 ? Time.realtimeSinceStartup : now }; buckets[key] = bucket; }
            float time = now < 0 ? Time.realtimeSinceStartup : now; bucket.tokens = Mathf.Min(capacity, bucket.tokens + Mathf.Max(0f, time - bucket.last) * refillPerSecond); bucket.last = time;
            if (bucket.tokens < cost) return false; bucket.tokens -= cost; return true;
        }
    }
}
