using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class SimpleMoveObj : MonoBehaviour
{
    [SerializeField] private Transform targetTrans;
    private bool isMoving = false;
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void ToggleMove()
    {
        isMoving = !isMoving;
    }
    private void FixedUpdate()
    {
        if (!isMoving)
            return;

        rb.position = Vector3.Lerp(transform.position, targetTrans.position, 1 * Time.fixedDeltaTime);
    }
}
