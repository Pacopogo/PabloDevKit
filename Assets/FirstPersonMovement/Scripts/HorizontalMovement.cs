using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PacoUtility
{
    public class HorizontalMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 6;

        private Vector2 inputDir;

        public void Move(InputAction.CallbackContext context) =>
            inputDir = context.ReadValue<Vector2>().normalized;

        private void FixedUpdate()
        {
            transform.Translate(Vector3.forward * inputDir.y * speed * Time.fixedDeltaTime);
            transform.Translate(Vector3.right * inputDir.x * speed * Time.fixedDeltaTime);
        }
    }
}
