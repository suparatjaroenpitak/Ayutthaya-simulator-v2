using System;
using System.Threading.Tasks;

namespace AyutthayaSimulator.Persistence
{
    public sealed class AuthSession { public string accountId; public string accessToken; public DateTime expiresAtUtc; public bool IsValid => !string.IsNullOrWhiteSpace(accountId) && !string.IsNullOrWhiteSpace(accessToken) && expiresAtUtc > DateTime.UtcNow; }
    public interface IAuthenticationProvider { Task<AuthSession> SignInAsync(string provider, string credential); Task<AuthSession> RefreshAsync(AuthSession session); Task SignOutAsync(AuthSession session); }
    public interface IOnlinePersistenceRepository
    {
        Task<PersistentSaveEnvelope> LoadAsync(AuthSession session, string slotId);
        Task<PersistenceResult> CommitAsync(AuthSession session, string slotId, PersistentSaveEnvelope data, string expectedRevision);
    }
    public interface IServerValidationGateway { bool ValidateClientIntent(string accountId, string operationId, string payloadHash); }
}
