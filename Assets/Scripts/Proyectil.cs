using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 20f; // Velocidad de la bala

    void Update()
    {
        // Mover la bala hacia adelante
        transform.Translate(Vector3.forward * velocidad * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificar si impacta con un enemigo
        if (other.CompareTag("Enemigo"))
        {
            // Mostrar un mensaje en la consola
            Debug.Log("La bala ha impactado con un enemigo.");

            // Destruir la bala despu�s del impacto
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Torreta")) // Evitar destruirse al tocar la torreta
        {
            // Destruir la bala si choca con cualquier otra cosa
            Destroy(gameObject);
        }
    }
}