using UnityEngine;
using System.Collections.Generic;

public class MovimientoEnemigo : MonoBehaviour
{
    public List<Transform> waypoints; // Lista de waypoints
    public float velocidad = 3.0f; // Velocidad de movimiento del monstruo
    public float velocidadRotacion = 5.0f; // Velocidad de rotaci�n del monstruo
    public int vida = 100; // Vida del zombie
    private int puntoActual = 0; // �ndice del waypoint actual
    private Animator animator; // Referencia al Animator del monstruo
    private bool estaMuerto = false; // Indica si el zombie est� muerto

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
        if (estaMuerto) return; // Si est� muerto, no hacer nada m�s

        // Movimiento hacia el waypoint
        if (puntoActual < waypoints.Count)
        {
            Transform objetivo = waypoints[puntoActual];
            Vector3 direccion = objetivo.position - transform.position;
            Quaternion rotacionObjetivo = Quaternion.LookRotation(direccion);

            transform.rotation = Quaternion.Slerp(transform.rotation, rotacionObjetivo, velocidadRotacion * Time.deltaTime);
            transform.position += direccion.normalized * velocidad * Time.deltaTime;

            if (direccion.magnitude < 0.1f)
            {
                puntoActual++;
            }
        }
        else
        {
            LlegarAlFinal();
        }
    }

    void LlegarAlFinal()
    {
        estaMuerto = true;
        animator.SetTrigger("Morir");
        Destroy(gameObject, 2f); // Destruye el zombie 2 segundos despu�s
    }

    public void RecibirDa�o(int cantidad)
    {
        if (estaMuerto) return; // No hacer nada si ya est� muerto

        vida -= cantidad;

        if (vida <= 0)
        {
            estaMuerto = true;
            animator.SetTrigger("Morir"); // Activar la animaci�n de muerte
            Destroy(gameObject, 2f); // Destruye el zombie despu�s de 2 segundos
        }
    }
}
