using UnityEngine;
using System.Collections.Generic;

public class MovimientoEnemigo : MonoBehaviour
{
    public List<Transform> waypoints; // Lista de waypoints
    public float velocidad = 3.0f; // Velocidad de movimiento del monstruo
    public float velocidadRotacion = 5.0f; // Velocidad de rotación del monstruo
    private int puntoActual = 0; // Índice del waypoint actual
    private Animator animator; // Referencia al Animator del monstruo

    void Start()
    {
        // Obtener el componente Animator
        animator = GetComponent<Animator>();

        // Asegúrate de que el monstruo empiece en el primer waypoint
        if (waypoints.Count > 0)
        {
            transform.position = waypoints[0].position;
        }
    }

    void Update()
    {
        // Si el monstruo aún no ha llegado al último waypoint
        if (puntoActual < waypoints.Count)
        {
            // Obtén la posición del siguiente waypoint
            Transform objetivo = waypoints[puntoActual];
            Vector3 direccion = objetivo.position - transform.position;

            // Calcula la rotación que mira hacia el siguiente waypoint
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
            // Al llegar al final, activar animación de "Morir" o cualquier otra acción
            animator.SetTrigger("Morir");  // Aquí activamos la animación de morir
            LlegarAlFinal();
        }
    }

    void LlegarAlFinal()
    {
        // Opcional: Acción a realizar cuando el monstruo llega al final del camino
        Destroy(gameObject); // Destruye al monstruo al llegar al final
    }

    // Función que puedes llamar cuando el monstruo necesite atacar
    public void Atacar()
    {
        animator.SetTrigger("Atacar");  // Activar la animación de ataque
    }
}