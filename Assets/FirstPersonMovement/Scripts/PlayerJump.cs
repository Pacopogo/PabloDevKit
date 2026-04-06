using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace PacoUtility
{
    public class PlayerJump : MonoBehaviour
    {
        [SerializeField] private Rigidbody rb;

        [Header("Settings")]
        [SerializeField] private float Jumpforce = 10;
        [SerializeField] private bool hasGravity = true;
        [SerializeField] private float gravity = 25;

        [Header("Ground Check")]
        [SerializeField] private LayerMask groundLayer;
        [SerializeField] private bool isGrounded;
        [SerializeField] private Vector3 boxSize = new Vector3(0.8f, 0.8f, 0.8f);
        [SerializeField] private float castDistance = 0.8f;

        private RaycastHit hit;

        public void Jump(InputAction.CallbackContext context)
        {
            if (!context.performed)
                return;

            if (!isGrounded)
                return;

            rb.linearVelocity = Vector3.up * Jumpforce;
        }

        private void FixedUpdate()
        {
            isGrounded = IsGrounded();

            if (!hasGravity)
                return;

            rb.linearVelocity += Vector3.down * gravity * Time.fixedDeltaTime;
        }
        public bool IsGrounded()
        {
            Vector3 halfExtents = boxSize / 2f;

            return Physics.BoxCast(
                transform.position, halfExtents, Vector3.down, out RaycastHit hit, Quaternion.identity, castDistance, groundLayer);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;

            Vector3 halfExtents = boxSize / 2f;

            Gizmos.DrawWireCube(transform.position, boxSize);

            Gizmos.DrawWireCube(transform.position + Vector3.down * castDistance, boxSize);
        }

    }
}
