using NUnit.Framework.Constraints;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TwoDPacoMovement
{
    public class HorizontalMovement : MonoBehaviour
    {
        [SerializeField] private float speed = 5;
        private float direction;

        public void DirectionInput(InputAction.CallbackContext context) => direction = context.ReadValue<Vector2>().x;

        private void FixedUpdate()
        {
            transform.Translate(Vector2.right * direction * speed * Time.fixedDeltaTime);
        }
    }
}
