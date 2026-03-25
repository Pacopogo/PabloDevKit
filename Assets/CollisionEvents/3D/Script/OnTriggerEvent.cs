using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class OnTriggerEvent : MonoBehaviour
{
    [SerializeField] private string tag = "Player";

    [SerializeField] private UnityEvent OnEnter;
    [SerializeField] private UnityEvent OnExit;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag(tag))
            return;

        OnEnter?.Invoke();
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.CompareTag(tag))
            return;

        OnExit?.Invoke();
    }
}
