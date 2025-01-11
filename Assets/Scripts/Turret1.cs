using UnityEngine;

public class Torreta1 : TurretBase
{
    public Transform canon1; // Posici�n del ca��n 1
    public Transform canon2; // Posici�n del ca��n 2
    private bool dispararDesdeCanon1 = true; // Controla desde qu� ca��n se dispara

    private void Start()
    {
        TurretLevel = 1;
        animator = GetComponent<Animator>();
    }
    protected override void Fire(Transform objetivo)
    {
        Vector3 direccion = (objetivo.position - transform.position).normalized;

        if (dispararDesdeCanon1)
        {
            Instantiate(bulletPrefab, canon1.position, Quaternion.LookRotation(direccion));
        }
        else
        {
            Instantiate(bulletPrefab, canon2.position, Quaternion.LookRotation(direccion));
        }

        dispararDesdeCanon1 = !dispararDesdeCanon1;
    }
}
