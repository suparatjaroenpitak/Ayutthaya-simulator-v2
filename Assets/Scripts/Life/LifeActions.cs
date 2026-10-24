using UnityEngine;

namespace AyutthayaSimulator.Life
{
    public sealed class LifeActions : MonoBehaviour
    {
        [SerializeField] private LifeSimulation simulation;
        [SerializeField] private Animator animator;
        public bool Eat(float hunger, float health = 0f) { if (simulation == null || !simulation.Eat(hunger, health)) return false; animator?.SetTrigger("Interact"); return true; }
        public bool Cook(float hunger, float health = 2f) { if (simulation == null || !simulation.Eat(hunger, health)) return false; animator?.SetTrigger("Interact"); return true; }
        public bool Rest(float minutes) { if (simulation == null || !simulation.Rest(minutes)) return false; animator?.SetTrigger("Interact"); return true; }
        public void BeginSleep() { simulation?.SetSleeping(true); animator?.SetBool("Sleep", true); }
        public void EndSleep() { simulation?.SetSleeping(false); animator?.SetBool("Sleep", false); }
    }
}
