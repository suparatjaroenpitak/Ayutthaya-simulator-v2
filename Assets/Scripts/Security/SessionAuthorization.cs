using System;
using System.Collections.Generic;
using UnityEngine;

namespace AyutthayaSimulator.Server
{
    [Serializable] public sealed class AuthorizedSession { public string accountId; public string sessionId; public DateTime expiresAtUtc; public bool revoked; public bool IsValid => !revoked && !string.IsNullOrWhiteSpace(accountId) && !string.IsNullOrWhiteSpace(sessionId) && expiresAtUtc > DateTime.UtcNow; }
    public sealed class SessionAuthorizationService : MonoBehaviour
    {
        private readonly Dictionary<string, AuthorizedSession> sessions = new Dictionary<string, AuthorizedSession>();
        public void Register(AuthorizedSession session) { if (session != null && !string.IsNullOrWhiteSpace(session.sessionId)) sessions[session.sessionId] = session; }
        public bool Validate(string accountId, string sessionId) => sessions.TryGetValue(sessionId, out AuthorizedSession session) && session.IsValid && session.accountId == accountId;
        public void Revoke(string sessionId) { if (sessions.TryGetValue(sessionId, out AuthorizedSession session)) session.revoked = true; }
    }
}
