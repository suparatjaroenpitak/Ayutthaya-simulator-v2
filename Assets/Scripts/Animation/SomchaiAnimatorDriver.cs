using UnityEngine;
using AyutthayaSimulator.Animation;

namespace AyutthayaSimulator.Runtime
{
    [RequireComponent(typeof(Animator))]
    public sealed class SomchaiAnimatorDriver : MonoBehaviour
    {
        public const string Speed = "Speed";
        public const string Grounded = "Grounded";
        public const string Running = "Running";
        public const string VerticalVelocity = "VerticalVelocity";
        public const string Interact = "Interact";
        public const string Sit = "Sit";
        public const string Sleep = "Sleep";
        public const string Farm = "Farm";

        [SerializeField] private Animator animator;
        [SerializeField] private ThirdPersonPlayer player;
        private SomchaiAnimationState state = SomchaiAnimationState.Locomotion;

        private void Awake() { if (animator == null) animator = GetComponent<Animator>(); }
        private void Update()
        {
            if (player == null || animator == null) return;
            animator.SetBool(Grounded, player.IsGrounded);
        }

        public void SetLocomotion(float speed, bool running, bool grounded, float verticalVelocity)
        {
            state = SomchaiAnimationState.Locomotion;
            animator.SetFloat(Speed, speed);
            animator.SetBool(Running, running);
            animator.SetBool(Grounded, grounded);
            animator.SetFloat(VerticalVelocity, verticalVelocity);
        }

        public void Request(SomchaiAnimationState requested)
        {
            state = requested;
            if (requested == SomchaiAnimationState.Interact) animator.SetTrigger(Interact);
            animator.SetBool(Sit, requested == SomchaiAnimationState.Sit);
            animator.SetBool(Sleep, requested == SomchaiAnimationState.Sleep);
            animator.SetBool(Farm, requested == SomchaiAnimationState.Farm);
        }

        public void OnAnimationEvent(string eventName) => SendMessage(eventName, SendMessageOptions.DontRequireReceiver);
        public SomchaiAnimationState CurrentState => state;
    }
}
