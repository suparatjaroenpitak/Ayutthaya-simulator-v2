using Unity.Netcode;
using UnityEngine;

namespace AyutthayaSimulator.Multiplayer
{
    public sealed class NetworkPlayerAvatar : NetworkBehaviour
    {
        [SerializeField] private float moveSpeed = 4.5f;
        [SerializeField] private float interpolation = 12f;
        [SerializeField] private Transform visual;
        public NetworkVariable<Vector3> ServerPosition = new NetworkVariable<Vector3>(default, NetworkVariableReadPermission.Everyone, NetworkVariableWritePermission.Server);
        private Vector3 targetPosition;
        public override void OnNetworkSpawn() { targetPosition = transform.position; ServerPosition.OnValueChanged += OnPositionChanged; if (IsServer) ServerPosition.Value = transform.position; }
        public override void OnNetworkDespawn() { ServerPosition.OnValueChanged -= OnPositionChanged; }
        private void Update()
        {
            if (IsOwner && IsClient) { Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")); SubmitInputServerRpc(Vector3.ClampMagnitude(new Vector3(input.x, 0f, input.y), 1f)); }
            if (!IsServer) transform.position = Vector3.Lerp(transform.position, targetPosition, 1f - Mathf.Exp(-interpolation * Time.deltaTime));
        }
        [ServerRpc] private void SubmitInputServerRpc(Vector3 direction, ServerRpcParams rpcParams = default)
        {
            if (rpcParams.Receive.SenderClientId != OwnerClientId || direction.sqrMagnitude > 1.01f) return;
            transform.position += direction * moveSpeed * Time.deltaTime; ServerPosition.Value = transform.position;
        }
        private void OnPositionChanged(Vector3 _, Vector3 next) => targetPosition = next;
    }
}
