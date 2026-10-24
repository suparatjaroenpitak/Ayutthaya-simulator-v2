using System;
using UnityEngine;
using AyutthayaSimulator.Security;

namespace AyutthayaSimulator.Server
{
    public enum ServerRequestKind { Economy, Inventory, Farming, Interaction, Movement }
    public readonly struct ServerRequest { public readonly string accountId, sessionId, requestId; public readonly ServerRequestKind kind; public readonly float receivedAt; public ServerRequest(string a, string s, string r, ServerRequestKind k, float t) { accountId = a; sessionId = s; requestId = r; kind = k; receivedAt = t; } }
    public sealed class ServerRequestGuard : MonoBehaviour
    {
        [SerializeField] private float requestsPerSecond = 20f;
        [SerializeField] private float burst = 40f;
        private TokenBucketRateLimiter limiter;
        private void Awake() => limiter = new TokenBucketRateLimiter(burst, requestsPerSecond);
        public bool Validate(ServerRequest request, Func<ServerRequest, bool> sessionValidator)
        {
            if (string.IsNullOrWhiteSpace(request.accountId) || string.IsNullOrWhiteSpace(request.sessionId) || string.IsNullOrWhiteSpace(request.requestId)) return false;
            if (sessionValidator == null || !sessionValidator(request)) return false;
            return limiter.TryConsume(request.accountId + ":" + request.kind);
        }
    }
}
