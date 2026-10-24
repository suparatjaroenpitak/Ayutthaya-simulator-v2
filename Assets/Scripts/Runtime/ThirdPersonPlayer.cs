using UnityEngine;
using UnityEngine.InputSystem;

namespace AyutthayaSimulator.Runtime
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class ThirdPersonPlayer : MonoBehaviour
    {
        [SerializeField] private GameConfig config;
        [SerializeField] private Transform cameraTransform;
        [SerializeField] private InputActionReference moveAction;
        [SerializeField] private InputActionReference runAction;
        [SerializeField] private InputActionReference jumpAction;
        [SerializeField] private InputActionReference interactAction;
        [SerializeField] private Animator animator;
        [SerializeField] private PlayerInteraction interaction;

        private CharacterController controller;
        private float verticalVelocity;
        private bool jumpQueued;
        private bool runHeld;

        private void Awake() => controller = GetComponent<CharacterController>();
        private void OnEnable()
        {
            moveAction?.action.Enable(); runAction?.action.Enable(); jumpAction?.action.Enable(); interactAction?.action.Enable();
            if (jumpAction != null) jumpAction.action.performed += OnJump;
            if (interactAction != null) interactAction.action.performed += OnInteract;
        }
        private void OnDisable()
        {
            if (jumpAction != null) jumpAction.action.performed -= OnJump;
            if (interactAction != null) interactAction.action.performed -= OnInteract;
            moveAction?.action.Disable(); runAction?.action.Disable(); jumpAction?.action.Disable(); interactAction?.action.Disable();
        }

        private void OnJump(UnityEngine.InputSystem.InputAction.CallbackContext _) => jumpQueued = true;
        private void OnInteract(UnityEngine.InputSystem.InputAction.CallbackContext _) => interaction?.TryInteract();

        private void Update()
        {
            if (config == null || cameraTransform == null) return;
            Vector2 input = moveAction == null ? Vector2.zero : moveAction.action.ReadValue<Vector2>();
            Vector3 forward = Vector3.ProjectOnPlane(cameraTransform.forward, Vector3.up).normalized;
            Vector3 right = Vector3.ProjectOnPlane(cameraTransform.right, Vector3.up).normalized;
            Vector3 direction = (forward * input.y + right * input.x);
            if (direction.sqrMagnitude > 1f) direction.Normalize();

            runHeld = runAction != null && runAction.action.IsPressed();
            bool running = runHeld && direction.sqrMagnitude > 0.001f;
            float speed = running ? config.runSpeed : config.walkSpeed;
            bool grounded = controller.isGrounded || Grounding.IsGrounded(transform, controller, config.groundProbeDistance);
            if (grounded && verticalVelocity < 0f) verticalVelocity = -config.groundedStickForce;
            if (grounded && jumpQueued)
                verticalVelocity = Mathf.Sqrt(config.jumpHeight * 2f * config.gravity);
            jumpQueued = false;
            verticalVelocity -= config.gravity * Time.deltaTime;
            Vector3 velocity = direction * speed + Vector3.up * verticalVelocity;
            controller.Move(velocity * Time.deltaTime);

            if (direction.sqrMagnitude > 0.001f)
            {
                Quaternion target = Quaternion.LookRotation(direction, Vector3.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, target, config.rotationSharpness * Time.deltaTime);
            }

            if (animator != null)
            {
                animator.SetFloat("Speed", new Vector3(velocity.x, 0f, velocity.z).magnitude);
                animator.SetBool("Grounded", grounded);
                animator.SetBool("Running", running);
                animator.SetFloat("VerticalVelocity", verticalVelocity);
            }
        }

        public CharacterController Controller => controller;
        public bool IsGrounded => controller != null && controller.isGrounded;
    }
}
