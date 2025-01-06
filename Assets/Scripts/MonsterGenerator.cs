using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MonsterGenerator : MonoBehaviour
{
    public GameObject prefabZombieBase; // Prefab de zombie normal
    public GameObject prefabZombieNivel2; // Prefab de zombie nivel 2
    public List<Transform> waypoints; // Lista de waypoints
    public float intervalo = 2.0f; // Intervalo inicial de tiempo entre cada monstruo
    public float intervaloMinimo = 0.5f; // Intervalo mínimo que puede llegar a tener
    public int enemigosPorAumento = 15; // Cada cuantos enemigos generados se aumenta la dificultad

    private int enemigosGenerados = 0; // Contador de enemigos generados
    private System.Random random = new System.Random(); // Generador de números aleatorios

    void Start()
    {
        StartCoroutine(GenerarEnemigos());
    }

    IEnumerator GenerarEnemigos()
    {
        while (true)
        {
            GameObject enemigoClonado;

            // Decidir qué tipo de enemigo generar
            if (enemigosGenerados >= 75)
            {
                enemigoClonado = Instantiate(prefabZombieNivel2, waypoints[0].position, Quaternion.identity);
            }
            else if (enemigosGenerados >= 15 && random.Next(100) < 40)
            {
                // 40% de probabilidad de generar un zombie de nivel 2
                enemigoClonado = Instantiate(prefabZombieNivel2, waypoints[0].position, Quaternion.identity);
            }
            else
            {
                // Generar un zombie normal
                enemigoClonado = Instantiate(prefabZombieBase, waypoints[0].position, Quaternion.identity);
            }

            // Activar el enemigo y configurar sus waypoints
            enemigoClonado.SetActive(true);
            MovimientoEnemigo scriptEnemigo = enemigoClonado.GetComponent<MovimientoEnemigo>();
            scriptEnemigo.waypoints = waypoints;

            // Incrementar el contador de enemigos generados
            enemigosGenerados++;

            // Reducir dificultad cada cierto número de enemigos
            if (enemigosGenerados % enemigosPorAumento == 0)
            {
                ReducirDificultad();
            }

            // Esperar antes de generar el siguiente enemigo
            yield return new WaitForSeconds(intervalo);
        }
    }

    void ReducirDificultad()
    {
        if (intervalo > intervaloMinimo)
        {
            intervalo -= 0.5f; // Reducir el intervalo en 0.1 segundos
            intervalo = Mathf.Max(intervalo, intervaloMinimo); // Asegurarse de que el intervalo no sea menor que el mínimo
        }
    }
}
