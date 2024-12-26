using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnerDeEnemigos : MonoBehaviour
{
    public GameObject prefabZombieBase; // Prefab de zombie1 que actúa como base (debe estar desactivado en la escena)
    public List<Transform> waypoints; // Lista de waypoints
    public float intervalo = 2.0f; // Intervalo de tiempo entre cada monstruo

    private GameObject zombieBaseClone; // Clonaremos este zombie base

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

            // Espera antes de generar el siguiente enemigo
            yield return new WaitForSeconds(intervalo);
        }
    }
}
