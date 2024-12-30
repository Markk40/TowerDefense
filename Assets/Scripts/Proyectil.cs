using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public float velocidad = 20f; // Velocidad de la bala
    public int daño = 20; // Daño que inflige la bala

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
            // Obtener el componente MovimientoEnemigo del enemigo
            MovimientoEnemigo enemigo = other.GetComponent<MovimientoEnemigo>();

            if (enemigo != null)
            {
                // Aplicar daño al enemigo
                enemigo.RecibirDaño(daño);
            }

            // Mostrar un mensaje en la consola
            //Debug.Log("La bala ha impactado con un enemigo.");

            // Destruir la bala después del impacto
            Destroy(gameObject);
        }
        else if (!other.CompareTag("Torreta")) // Evitar destruirse al tocar la torreta
        {
            // Destruir la bala si choca con cualquier otra cosa
            Destroy(gameObject);
        }
    }
}
