using System.Threading.Tasks;
using UnityEngine;

namespace AyutthayaSimulator.Persistence
{
    public sealed class OnlinePersistenceClient : MonoBehaviour
    {
        [SerializeField] private MonoBehaviour authComponent;
        [SerializeField] private MonoBehaviour repositoryComponent;
        private IAuthenticationProvider auth; private IOnlinePersistenceRepository repository; private AuthSession session; private string revision;
        public PersistenceFailure LastFailure { get; private set; }
        private void Awake() { auth = authComponent as IAuthenticationProvider; repository = repositoryComponent as IOnlinePersistenceRepository; }
        public async Task<PersistenceResult> SignIn(string provider, string credential) { if (auth == null) return Fail(PersistenceFailure.NotAuthenticated, "Authentication provider is not configured."); session = await auth.SignInAsync(provider, credential); return session != null && session.IsValid ? PersistenceResult.Ok() : Fail(PersistenceFailure.NotAuthenticated, "Authentication failed."); }
        public async Task<PersistenceResult> Load(string slotId, System.Action<PersistentSaveEnvelope> apply) { if (session == null || !session.IsValid || repository == null) return Fail(PersistenceFailure.NotAuthenticated, "No valid session."); try { PersistentSaveEnvelope data = await repository.LoadAsync(session, slotId); if (data == null) return Fail(PersistenceFailure.NetworkUnavailable, "Server returned no save."); apply?.Invoke(data); return PersistenceResult.Ok(); } catch (System.Exception ex) { return Fail(PersistenceFailure.NetworkUnavailable, ex.Message); } }
        public async Task<PersistenceResult> Commit(string slotId, PersistentSaveEnvelope data) { if (session == null || !session.IsValid || repository == null) return Fail(PersistenceFailure.NotAuthenticated, "No valid session."); try { PersistenceResult result = await repository.CommitAsync(session, slotId, data, revision); if (!result.success) LastFailure = result.failure; return result; } catch (System.Exception ex) { return Fail(PersistenceFailure.NetworkUnavailable, ex.Message); } }
        public async Task<PersistenceResult> ReconnectAndRecover() { if (auth == null || session == null) return Fail(PersistenceFailure.NotAuthenticated, "No session to refresh."); try { session = await auth.RefreshAsync(session); return session != null && session.IsValid ? PersistenceResult.Ok() : Fail(PersistenceFailure.NotAuthenticated, "Session refresh failed."); } catch (System.Exception ex) { return Fail(PersistenceFailure.NetworkUnavailable, ex.Message); } }
        private PersistenceResult Fail(PersistenceFailure failure, string message) { LastFailure = failure; return PersistenceResult.Fail(failure, message); }
    }
}
