using UnityEngine;
using UnityEngine.SceneManagement; // Para reiniciar o cargar la escena de fin del juego

public class Castillo : MonoBehaviour
{
    public int vidaMaxima = 100; // Vida total del castillo
    private int vidaActual; // Vida actual del castillo

    void Start()
    {
        // Inicializamos la vida del castillo
        vidaActual = vidaMaxima;
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto que colisiona es un zombi
        if (other.CompareTag("Enemigo"))
        {
            // Da�o que recibe el castillo
            int dano = 5; // Ajusta el da�o seg�n sea necesario

            // Reducimos la vida del castillo
            RecibirDanio(dano);

            // Opcional: Destruye al zombi despu�s de causar da�o
            Destroy(other.gameObject);
        }
    }

    public void RecibirDanio(int cantidad)
    {
        vidaActual -= cantidad;

        // Aseg�rate de que la vida no sea negativa
        if (vidaActual <= 0)
        {
            vidaActual = 0;
            FinDelJuego(); // Llama a la funci�n de fin del juego
        }

        // Mostrar la vida del castillo en la consola (opcional)
        Debug.Log("Vida del castillo: " + vidaActual);
    }

    void FinDelJuego()
    {
        Debug.Log("�El castillo ha ca�do! Fin del juego.");

        // Puedes cargar una escena de "Game Over"
        SceneManager.LoadScene("GameOver");
    }
}
