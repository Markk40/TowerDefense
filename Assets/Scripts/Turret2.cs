using UnityEngine;

public class TurretLevel2 : TurretBase
{
    public Transform firePoint; // Posici�n desde donde dispara la torreta

    private void Start()
    {
        TurretLevel = 2;
    }

    protected override void Fire(Transform target)
    {
        Vector3 direction = (target.position - transform.position).normalized;

        // Disparar desde un �nico punto
        Instantiate(bulletPrefab, firePoint.position, Quaternion.LookRotation(direction));
    }
}

