using UnityEngine;

public class Torreta2 : TorretaBase
{
    public Transform puntoDisparo; // Posici�n desde donde dispara la torreta

    private void Start()
    {
        NivelTorreta = 2;
    }
    protected override void Disparar(Transform objetivo)
    {
        Vector3 direccion = (objetivo.position - transform.position).normalized;

        // Disparar desde un �nico punto
        Instantiate(prefabBala, puntoDisparo.position, Quaternion.LookRotation(direccion));
    }
}
