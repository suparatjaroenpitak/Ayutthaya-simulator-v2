using UnityEngine;

namespace AyutthayaSimulator.Operations
{
    public sealed class LoadTestHarness : MonoBehaviour
    {
        [SerializeField] private int virtualPlayers = 100;
        [SerializeField] private float requestsPerSecond = 5f;
        [SerializeField] private ServerObservability observability;
        private float accumulator;
        private void Update()
        {
            if (observability == null || virtualPlayers <= 0) return;
            accumulator += Time.deltaTime * requestsPerSecond;
            int requests = Mathf.FloorToInt(accumulator); if (requests <= 0) return; accumulator -= requests;
            observability.Increment("loadtest.virtual_players", virtualPlayers); observability.Increment("loadtest.requests", requests * virtualPlayers);
        }
    }
}
