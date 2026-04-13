using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5;
    private Vector2 inputDir;
    public void MoveInput(InputAction.CallbackContext context)
    {
        inputDir = context.ReadValue<Vector2>().normalized;
    }

    public void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        transform.Translate(Vector2.up * inputDir.y * walkSpeed * Time.fixedDeltaTime);
        transform.Translate(Vector2.right * inputDir.x * walkSpeed * Time.fixedDeltaTime);
    }
}
