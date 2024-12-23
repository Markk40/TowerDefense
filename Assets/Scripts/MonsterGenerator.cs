using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerDeEnemigos : MonoBehaviour
{
    public GameObject prefabEnemigo; // Prefab del monstruo
    public List<Transform> waypoints; // Lista de waypoints
    public float intervalo = 2.0f; // Intervalo de tiempo entre cada monstruo

    void Start()
    {
        StartCoroutine(GenerarEnemigos());
    }

    IEnumerator GenerarEnemigos()
    {
        while (true)
        {
            // Instancia el monstruo en la posición del primer waypoint
            GameObject enemigo = Instantiate(prefabEnemigo, waypoints[0].position, Quaternion.identity);

            // Pasa los waypoints al script del enemigo
            MovimientoEnemigo scriptEnemigo = enemigo.GetComponent<MovimientoEnemigo>();
            scriptEnemigo.waypoints = waypoints;

            yield return new WaitForSeconds(intervalo); // Espera antes de generar el siguiente enemigo
        }
    }
}
