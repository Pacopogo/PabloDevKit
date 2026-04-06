using UnityEngine;
using UnityEngine.InputSystem;

namespace PacoUtility
{
    /// <summary>
    /// This is a camera controller for a first person controller
    /// </summary>
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform cameraTrans;

        [Header("Settings")]
        public float mouseSensitivy = 12;
        [SerializeField] private Vector2 UpwardsRange = new Vector2(-60, 80);

        private Vector3 cameraVector;
        private Vector2 mouseDelta;

        private void Start()
        {
            SetCursor(CursorLockMode.Locked);
        }
        public void OnMouseMove(InputAction.CallbackContext context)
        {
            mouseDelta = context.ReadValue<Vector2>();
        }

        private void FixedUpdate()
        {
            transform.Rotate(Vector3.up * mouseDelta.x * mouseSensitivy * Time.fixedDeltaTime);

            cameraVector.x -= mouseDelta.y * mouseSensitivy * Time.fixedDeltaTime;
            cameraVector.x = Mathf.Clamp(cameraVector.x, UpwardsRange.x, UpwardsRange.y);

            cameraTrans.localRotation = Quaternion.Euler(cameraVector);
        }

        public void SetCursor(CursorLockMode lockMode) => Cursor.lockState = lockMode;
        public void UnlockMouse() => Cursor.lockState = CursorLockMode.None;
        public void LockMouse() => Cursor.lockState = CursorLockMode.Locked;
    }
}
