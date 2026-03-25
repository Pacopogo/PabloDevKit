using UnityEngine;
using UnityEngine.Events;

[RequireComponent (typeof(Rigidbody))]
public class OnCollisonEvent : MonoBehaviour
{
    [SerializeField] private string tag = "Player";

    [SerializeField] private UnityEvent OnEnter;
    [SerializeField] private UnityEvent OnExit;

    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag(tag))
            return;

        OnEnter?.Invoke();
    }
    private void OnCollisionExit(Collision collision)
    {
        if (!collision.gameObject.CompareTag(tag))
            return;

        OnExit?.Invoke();
    }
}
