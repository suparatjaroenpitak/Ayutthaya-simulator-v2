using UnityEngine;
using UnityEngine.InputSystem;

namespace AyutthayaSimulator.WorldPrototype
{
    [RequireComponent(typeof(CharacterController))]
    public sealed class PrototypeExplorer : MonoBehaviour
    {
        public Camera view;
        public float walkSpeed = 4.5f, runSpeed = 8f, jumpHeight = 1.2f;
        public float cameraDistance = 5f;
        private CharacterController controller;
        private Vector3 spawn;
        private float vertical, yaw, pitch = 20f;
        void Awake() { controller = GetComponent<CharacterController>(); spawn = transform.position; }
        void Update()
        {
            if (view == null || Keyboard.current == null) return;
            var k = Keyboard.current;
            if (Mouse.current != null && Mouse.current.rightButton.isPressed)
            {
                Vector2 delta = Mouse.current.delta.ReadValue(); yaw += delta.x * .12f; pitch = Mathf.Clamp(pitch - delta.y * .12f, -20, 70);
            }
            Vector3 move = new Vector3((k.dKey.isPressed ? 1 : 0)-(k.aKey.isPressed ? 1 : 0),0,(k.wKey.isPressed ? 1 : 0)-(k.sKey.isPressed ? 1 : 0));
            move = Quaternion.Euler(0,yaw,0) * Vector3.ClampMagnitude(move,1);
            if(controller.isGrounded && vertical < 0) vertical = -2;
            if(controller.isGrounded && k.spaceKey.wasPressedThisFrame) vertical = Mathf.Sqrt(2*25*jumpHeight);
            vertical = Mathf.Max(-50,vertical-25*Time.deltaTime);
            controller.Move((move*(k.leftShiftKey.isPressed?runSpeed:walkSpeed)+Vector3.up*vertical)*Mathf.Min(Time.deltaTime,.05f));
            if(move.sqrMagnitude > .01f) transform.rotation=Quaternion.LookRotation(move);
            if(transform.position.y < -20 || k.rKey.wasPressedThisFrame) { controller.enabled=false; transform.position=spawn; vertical=0; controller.enabled=true; }
        }
        void LateUpdate()
        {
            if(view==null) return;
            Vector3 pivot=transform.position+Vector3.up*1.5f;
            Quaternion rotation=Quaternion.Euler(pitch,yaw,0);
            Vector3 back=rotation*Vector3.back;
            float distance=cameraDistance;
            if(Physics.SphereCast(pivot,.2f,back,out RaycastHit hit,distance,~(1<<2),QueryTriggerInteraction.Ignore)) distance=Mathf.Max(.2f,hit.distance-.1f);
            view.transform.SetPositionAndRotation(pivot+back*distance,rotation);
        }
    }
}
