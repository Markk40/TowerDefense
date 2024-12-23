using UnityEngine;
using System.Collections.Generic;

public class Torreta : MonoBehaviour
{
    public Transform canon1; // Posición del cañón 1
    public Transform canon2; // Posición del cañón 2
    public GameObject prefabBala; // Prefab de la bala
    public float tiempoEntreDisparos = 1f; // Intervalo entre disparos

    private float temporizadorDisparo = 0f;
    private bool dispararDesdeCanon1 = true; // Controla desde qué cañón se dispara
    private List<GameObject> enemigosEnRango = new List<GameObject>(); // Lista de enemigos dentro del rango

    void Update()
    {
        temporizadorDisparo += Time.deltaTime;

        // Buscar al enemigo más cercano en la lista de enemigos en rango
        GameObject enemigoMasCercano = ObtenerEnemigoMasCercano();

        if (enemigoMasCercano != null)
        {
            // Apuntar hacia el enemigo más cercano
            ApuntarAlEnemigo(enemigoMasCercano.transform);

            // Disparar si es el momento adecuado
            if (temporizadorDisparo >= tiempoEntreDisparos)
            {
                Disparar(enemigoMasCercano.transform);
                temporizadorDisparo = 0f;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Si un enemigo entra en el rango, añadirlo a la lista
        if (other.CompareTag("Enemigo"))
        {
            enemigosEnRango.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        // Si un enemigo sale del rango, eliminarlo de la lista
        if (other.CompareTag("Enemigo"))
        {
            enemigosEnRango.Remove(other.gameObject);
        }
    }

    GameObject ObtenerEnemigoMasCercano()
    {
        GameObject enemigoMasCercano = null;
        float distanciaMinima = Mathf.Infinity;

        foreach (GameObject enemigo in enemigosEnRango)
        {
            if (enemigo != null) // Verificar que el enemigo no haya sido destruido
            {
                float distancia = Vector3.Distance(transform.position, enemigo.transform.position);
                if (distancia < distanciaMinima)
                {
                    distanciaMinima = distancia;
                    enemigoMasCercano = enemigo;
                }
            }
        }

        return enemigoMasCercano;
    }

    void ApuntarAlEnemigo(Transform enemigo)
    {
        Vector3 direccion = (enemigo.position - transform.position).normalized;
        Quaternion rotacionHaciaEnemigo = Quaternion.LookRotation(direccion);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotacionHaciaEnemigo, Time.deltaTime * 5f);
    }

    void Disparar(Transform objetivo)
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