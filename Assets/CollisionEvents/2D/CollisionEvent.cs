using UnityEngine;
using UnityEngine.Events;

namespace TwoDCollison
{
    public class CollisionEvent : MonoBehaviour
    {
        [SerializeField] private string playerTag = "Player";

        [SerializeField] private UnityEvent OnEnter;
        [SerializeField] private UnityEvent OnExit;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag(playerTag))
                return;

            OnEnter?.Invoke();

        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (!collision.gameObject.CompareTag(playerTag))
                return;

            OnExit?.Invoke();
        }
    }
}
