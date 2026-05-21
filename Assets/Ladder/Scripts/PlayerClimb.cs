using UnityEngine;

namespace PacoUtility
{
    public class PlayerClimb : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private PlayerJump playerJump;
        [SerializeField] private HorizontalMovement playerMovement;

        [Header("Settings")]
        [SerializeField] private string climbMask = "Ladder";
        [SerializeField] private float climbStrength = 10;

        private float originalGravity;
        public bool isClimbing = false;

        private void Start()
        {
            originalGravity = playerJump.gravity;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.CompareTag(climbMask))
                return;

            playerJump.gravity = 0;

            isClimbing = true;
        }

        private void OnCollisionExit(Collision collision)
        {
            if (!collision.gameObject.CompareTag(climbMask))
                return;

            playerJump.gravity = originalGravity;

            isClimbing = false;
        }

        private void FixedUpdate()
        {
            if (!isClimbing)
                return;

            transform.Translate(Vector3.up * Mathf.Abs(playerMovement.inputDir.y) * climbStrength * Time.fixedDeltaTime);
        }
    }
}
