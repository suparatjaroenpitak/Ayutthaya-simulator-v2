using UnityEngine;

namespace AyutthayaSimulator.Operations
{
    [CreateAssetMenu(menuName = "Ayutthaya/Operations/Transport Security Config", fileName = "TransportSecurityConfig")]
    public sealed class TransportSecurityConfig : ScriptableObject
    {
        public bool requireAuthenticatedRelay = true;
        public bool allowDirectIpForDevelopment = true;
        public bool rejectUnencryptedProductionTransport = true;
        public string certificateProviderContract = "Configure TLS/DTLS or a trusted Relay provider in deployment adapter";
        public bool IsProductionSafeWithoutAdapter => !rejectUnencryptedProductionTransport;
    }
}
