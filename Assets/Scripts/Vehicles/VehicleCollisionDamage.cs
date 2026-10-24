using UnityEngine;

namespace AyutthayaSimulator.Vehicles
{
    public sealed class VehicleCollisionDamage : MonoBehaviour
    {
        [SerializeField] private float impactThreshold = 5f;
        [SerializeField] private float maxDamage = 100f;
        public float Damage { get; private set; }
        private void OnCollisionEnter(Collision collision)
        {
            float impact = collision.relativeVelocity.magnitude;
            if (impact <= impactThreshold) return;
            Damage = Mathf.Min(maxDamage, Damage + impact - impactThreshold);
        }
    }
}
