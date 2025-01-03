using UnityEngine;
using System.Collections.Generic;

public abstract class TorretaBase : MonoBehaviour
{
    public GameObject prefabBala; // Prefab de la bala
    public float tiempoEntreDisparos = 1f; // Intervalo entre disparos
    private int nivelTorreta = 1;

    protected float temporizadorDisparo = 0f;
    protected List<GameObject> enemigosEnRango = new List<GameObject>(); // Lista de enemigos dentro del rango
    protected Animator animator;
    void Start()
    {
        animator = GetComponent<Animator>(); // Inicializa el Animator
    }

    void Update()
    {
        temporizadorDisparo += Time.deltaTime;

        // Buscar al enemigo m�s cercano en la lista de enemigos en rango
        GameObject enemigoMasCercano = ObtenerEnemigoMasCercano();

        if (enemigoMasCercano != null)
        {
            // Apuntar hacia el enemigo m�s cercano
            ApuntarAlEnemigo(enemigoMasCercano.transform);

            // Disparar si es el momento adecuado
            if (temporizadorDisparo >= tiempoEntreDisparos)
            {
                Disparar(enemigoMasCercano.transform);
                temporizadorDisparo = 0f;

                // Activar la animaci�n de disparo
                if (animator != null && NivelTorreta == 1)
                {
                    animator.SetBool("isShooting", true); // Cambia este nombre por el par�metro que uses en el Animator
                }
            }
        }
        else
        {
            if (animator != null && NivelTorreta == 1)
            {
                animator.SetBool("isShooting", false);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Si un enemigo entra en el rango, a�adirlo a la lista
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

    protected void ApuntarAlEnemigo(Transform enemigo)
    {
        Vector3 direccion = (enemigo.position - transform.position).normalized;
        Quaternion rotacionHaciaEnemigo = Quaternion.LookRotation(direccion);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotacionHaciaEnemigo, Time.deltaTime * 5f);
    }

    protected abstract void Disparar(Transform objetivo); // M�todo abstracto para que cada torreta implemente su disparo espec�fico

    public int NivelTorreta
    {
        get => nivelTorreta;
        set => nivelTorreta = value;
    }
}
