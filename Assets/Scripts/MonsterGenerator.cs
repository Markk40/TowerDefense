using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerDeEnemigos : MonoBehaviour
{
    public GameObject prefabZombieBase; // Prefab de zombie que actúa como base (debe estar desactivado en la escena)
    public List<Transform> waypoints; // Lista de waypoints
    public float intervalo = 2.0f; // Intervalo inicial de tiempo entre cada monstruo
    public float intervaloMinimo = 0.5f; // Intervalo mínimo que puede llegar a tener
    public int enemigosPorAumento = 5; // Cada cuantos enemigos generados se aumenta la dificultad

    private GameObject zombieBaseClone; // Clonaremos este zombie base
    private int enemigosGenerados = 0; // Contador de enemigos generados

    void Start()
    {
        // Clonar el zombie base solo una vez y desactivarlo
        zombieBaseClone = Instantiate(prefabZombieBase, transform.position, Quaternion.identity);
        zombieBaseClone.SetActive(false); // Este zombie no debe aparecer en la escena, solo se usa para clonación
        StartCoroutine(GenerarEnemigos());
    }

    IEnumerator GenerarEnemigos()
    {
        while (true)
        {
            // Clonamos el zombie base para generar un nuevo enemigo
            GameObject enemigoClonado = Instantiate(zombieBaseClone, waypoints[0].position, Quaternion.identity);
            enemigoClonado.SetActive(true); // Activamos el clon para que sea visible e interactúe

            // Pasa los waypoints al script del enemigo
            MovimientoEnemigo scriptEnemigo = enemigoClonado.GetComponent<MovimientoEnemigo>();
            scriptEnemigo.waypoints = waypoints;

            // Incrementamos el contador de enemigos generados
            enemigosGenerados++;

            // Cada cierto número de enemigos generados, reducimos el intervalo entre generaciones
            if (enemigosGenerados % enemigosPorAumento == 0)
            {
                ReducirDificultad();
            }

            // Espera antes de generar el siguiente enemigo
            yield return new WaitForSeconds(intervalo);
        }
    }

    // Función que reduce el intervalo entre enemigos, hasta un mínimo
    void ReducirDificultad()
    {
        if (intervalo > intervaloMinimo)
        {
            intervalo -= 0.1f; // Reducir el intervalo en 0.1 segundos
            intervalo = Mathf.Max(intervalo, intervaloMinimo); // Asegurarse de que el intervalo no sea menor que el mínimo
        }
    }
}
