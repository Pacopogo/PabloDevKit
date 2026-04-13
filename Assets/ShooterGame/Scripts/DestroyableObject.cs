using UnityEngine;
using UnityEngine.Events;

public class DestroyableObject : MonoBehaviour, IDamageable
{
    [SerializeField] private int health = 1;
    [SerializeField] private UnityEvent OnDeath;
    public void OnDamage()
    {
        if (health < 1)
            return;

        --health;

        if (health < 1)
            OnDeath?.Invoke();

    }

}
