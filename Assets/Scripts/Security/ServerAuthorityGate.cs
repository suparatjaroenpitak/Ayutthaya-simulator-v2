using UnityEngine;

namespace AyutthayaSimulator.Server
{
    public interface IServerAuthorityGate { bool CanMutate(string accountId, string sessionId, string operationId); }
    public sealed class ServerAuthorityGate : MonoBehaviour, IServerAuthorityGate
    {
        [SerializeField] private SessionAuthorizationService sessions;
        [SerializeField] private ServerRequestGuard requests;
        public bool CanMutate(string accountId, string sessionId, string operationId)
        {
            ServerRequest request = new ServerRequest(accountId, sessionId, operationId, ServerRequestKind.Interaction, Time.realtimeSinceStartup);
            return sessions != null && requests != null && requests.Validate(request, r => sessions.Validate(r.accountId, r.sessionId));
        }
    }
}
