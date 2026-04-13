using UnityEngine;
using UnityEngine.InputSystem;

public class TwoDJump : MonoBehaviour
{
    [SerializeField] private float jumpForce = 5;
    private Rigidbody2D rb;

    [Header("Gravity")]
    [SerializeField] private bool HasGravity = true;
    [SerializeField] private float gravity = 11;

    [Header("Ground Check")]
    [SerializeField] private float groundDistance = 1;
    [SerializeField] private Vector2 boxSize = new Vector3(0.8f, 0.8f, 0.8f);
    [SerializeField] private LayerMask groundMask;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        if (!GroundCheck())
            return;

        rb.linearVelocityY = jumpForce;
    }

    public void FixedUpdate()
    {
        GroundCheck();

        if (!HasGravity)
            return;
        rb.linearVelocity += Vector2.down * gravity * Time.fixedDeltaTime;
    }

    private bool GroundCheck()
    {
        Vector2 halfExtents = boxSize / 2f;

        return Physics2D.BoxCast(transform.position, halfExtents, 0, Vector2.down, groundDistance, groundMask);
    }
}
