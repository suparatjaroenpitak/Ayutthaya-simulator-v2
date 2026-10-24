using NUnit.Framework;
using UnityEngine;
using AyutthayaSimulator.Security;
using AyutthayaSimulator.Server;

public sealed class SecurityTests
{
    [Test] public void RateLimiter_RejectsBurstAfterCapacity()
    {
        TokenBucketRateLimiter limiter = new TokenBucketRateLimiter(2, 0.1f); Assert.IsTrue(limiter.TryConsume("a", 1, 0)); Assert.IsTrue(limiter.TryConsume("a", 1, 0)); Assert.IsFalse(limiter.TryConsume("a", 1, 0));
    }
    [Test] public void MovementValidator_RejectsTeleport()
    {
        GameObject go = new GameObject("Movement"); MovementSanityValidator validator = go.AddComponent<MovementSanityValidator>(); Assert.IsTrue(validator.Accept("a", Vector3.zero, 0.1f)); Assert.IsFalse(validator.Accept("a", new Vector3(1000, 0, 0), 0.1f)); Object.DestroyImmediate(go);
    }
    [Test] public void SessionAuthorization_RejectsRevokedSession()
    {
        GameObject go = new GameObject("Auth"); SessionAuthorizationService auth = go.AddComponent<SessionAuthorizationService>(); AuthorizedSession session = new AuthorizedSession { accountId = "a", sessionId = "s", expiresAtUtc = System.DateTime.UtcNow.AddMinutes(1) }; auth.Register(session); Assert.IsTrue(auth.Validate("a", "s")); auth.Revoke("s"); Assert.IsFalse(auth.Validate("a", "s")); Object.DestroyImmediate(go);
    }
}
