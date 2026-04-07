using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PacoUtility
{
    public class HorizontalMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 6;

        [Header("Sprinting")]
        [SerializeField] private bool canSprint = true;
        private bool isSprinting = false;
        [SerializeField] private float sprintSpeed = 12;

        private Vector2 inputDir;

        public void Move(InputAction.CallbackContext context) =>
            inputDir = context.ReadValue<Vector2>().normalized;

        public void Sprint(InputAction.CallbackContext context)
        {
            isSprinting = context.action.inProgress ? true : false;
        }

        private void FixedUpdate()
        {
            float moveSpeed = speed;

            if (canSprint)
                moveSpeed = isSprinting ? sprintSpeed : speed;

            transform.Translate(Vector3.forward * inputDir.y * moveSpeed * Time.fixedDeltaTime);
            transform.Translate(Vector3.right * inputDir.x * moveSpeed * Time.fixedDeltaTime);
        }

    }
}
