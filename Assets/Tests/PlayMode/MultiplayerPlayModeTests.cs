using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using AyutthayaSimulator.Server;

public sealed class MultiplayerPlayModeTests
{
    [UnityTest] public IEnumerator InvalidAuthorityRequest_IsRejected()
    {
        GameObject authObject = new GameObject("Sessions"); SessionAuthorizationService auth = authObject.AddComponent<SessionAuthorizationService>(); AuthorizedSession session = new AuthorizedSession { accountId = "client-a", sessionId = "session-a", expiresAtUtc = System.DateTime.UtcNow.AddMinutes(1) }; auth.Register(session); yield return null; Assert.IsFalse(auth.Validate("client-b", "session-a")); Object.Destroy(authObject);
    }
    [UnityTest] public IEnumerator TwoClientScenario_IsExplicitlyNotClaimedWithoutNetworkHarness()
    {
        yield return null; Assert.Ignore("Two-client execution must run in Multiplayer Play Mode or standalone builds; this fixture is an explicit gate, not a fabricated pass.");
    }
}
