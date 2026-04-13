using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


public class SimpleGun : MonoBehaviour
{
    [SerializeField] private Transform gunPoint;

    [Header("Settings")]
    [SerializeField] private LayerMask hitMask;
    [SerializeField] private float shootRange = 30;
    [SerializeField] private bool infinitAmmo = false;
    [SerializeField] private int maxAmmo = 6;
    [SerializeField] private int currentAmmo = 6;

    [SerializeField] private float reloadTime = 1;
    [SerializeField] private bool autoReload = false;
    private bool isReloading;

    [SerializeField] private UnityEvent OnShoot;
    [SerializeField] private UnityEvent OnEmptyClip;
    [SerializeField] private UnityEvent OnReload;

    public void Shoot(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

        SimpleShot();
    }

    public void Reload(InputAction.CallbackContext context)
    {
        if (!context.performed || currentAmmo == maxAmmo || isReloading)
            return;

        isReloading = true;
        StartCoroutine(Reloading());
    }

    public void SimpleShot()
    {
        if (!UseAmmo())
            return;

        RaycastHit hit;
        if (Physics.Raycast(gunPoint.position, gunPoint.TransformDirection(Vector3.forward), out hit, shootRange, hitMask))
        {
            Debug.DrawRay(gunPoint.position, gunPoint.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            IDamageable obj = hit.collider.gameObject.GetComponent<IDamageable>();

            if (obj != null)
            {
                obj.OnDamage();
            }
        }

        OnShoot?.Invoke();
    }
    public bool UseAmmo()
    {
        if (infinitAmmo)
            return true;

        if (currentAmmo > 0)
        {
            --currentAmmo;
            return true;
        }
        else
        {
            OnEmptyClip?.Invoke();
            currentAmmo = 0;

            if (autoReload && !isReloading)
            {
                isReloading = true;
                StartCoroutine(Reloading());
            }

            return false;
        }
    }

    public IEnumerator Reloading()
    {

        yield return new WaitForSeconds(reloadTime);

        currentAmmo = maxAmmo;
        isReloading = false;
    }
}
