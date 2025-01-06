using UnityEngine;

public class Torreta1 : TorretaBase
{
    public Transform canon1; // Posici�n del ca��n 1
    public Transform canon2; // Posici�n del ca��n 2
    private bool dispararDesdeCanon1 = true; // Controla desde qu� ca��n se dispara

    private void Start()
    {
        NivelTorreta = 1;
        animator = GetComponent<Animator>();
    }
    protected override void Disparar(Transform objetivo)
    {
        Vector3 direccion = (objetivo.position - transform.position).normalized;

        if (dispararDesdeCanon1)
        {
            Instantiate(prefabBala, canon1.position, Quaternion.LookRotation(direccion));
        }
        else
        {
            Instantiate(prefabBala, canon2.position, Quaternion.LookRotation(direccion));
        }

        dispararDesdeCanon1 = !dispararDesdeCanon1;
    }
}
