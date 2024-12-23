using UnityEngine;
using System.Collections.Generic;

public class MovimientoEnemigo : MonoBehaviour
{
    public List<Transform> waypoints; // Lista de waypoints
    public float velocidad = 3.0f; // Velocidad de movimiento del monstruo
    public float velocidadRotacion = 5.0f; // Velocidad de rotaci�n del monstruo
    private int puntoActual = 0; // �ndice del waypoint actual
    private Animator animator; // Referencia al Animator del monstruo

    void Start()
    {
        // Obtener el componente Animator
        animator = GetComponent<Animator>();

        // Aseg�rate de que el monstruo empiece en el primer waypoint
        if (waypoints.Count > 0)
        {
            transform.position = waypoints[0].position;
        }
    }

    void Update()
    {
        // Si el monstruo a�n no ha llegado al �ltimo waypoint
        if (puntoActual < waypoints.Count)
        {
            // Obt�n la posici�n del siguiente waypoint
            Transform objetivo = waypoints[puntoActual];
            Vector3 direccion = objetivo.position - transform.position;

            // Calcula la rotaci�n que mira hacia el siguiente waypoint
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);

            // Gira el monstruo suavemente hacia el siguiente waypoint
            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, velocidadRotacion * Time.deltaTime);

            // Mueve el monstruo hacia el siguiente waypoint
            transform.position += direccion.normalized * velocidad * Time.deltaTime;

            // Verificar si ha llegado al waypoint actual
            if (direccion.magnitude < 0.1f)
            {
                puntoActual++; // Pasar al siguiente waypoint
            }
        }
        else
        {
            // Al llegar al final, activar animaci�n de "Morir" o cualquier otra acci�n
            animator.SetTrigger("Morir");  // Aqu� activamos la animaci�n de morir
            LlegarAlFinal();
        }
    }

    void LlegarAlFinal()
    {
        // Opcional: Acci�n a realizar cuando el monstruo llega al final del camino
        Destroy(gameObject); // Destruye al monstruo al llegar al final
    }

    // Funci�n que puedes llamar cuando el monstruo necesite atacar
    public void Atacar()
    {
        animator.SetTrigger("Atacar");  // Activar la animaci�n de ataque
    }
}