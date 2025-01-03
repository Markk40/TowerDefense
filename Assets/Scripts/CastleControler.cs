using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement; // Para reiniciar o cargar la escena de fin del juego

public class Castillo : MonoBehaviour
{
    public int vidaMaxima = 100; // Vida total del castillo
    private int vidaActual; // Vida actual del castillo
    public Image healthBarFill;
    public TextMeshProUGUI healthText;

    void Start()
    {
        // Inicializamos la vida del castillo
        vidaActual = vidaMaxima;
        UpdateHealthBar();
    }

    void OnTriggerEnter(Collider other)
    {
        // Verificamos si el objeto que colisiona es un zombi
        if (other.CompareTag("Enemigo"))
        {
            // Daño que recibe el castillo
            int dano = 5; // Ajusta el daño según sea necesario

            // Reducimos la vida del castillo
            RecibirDanio(dano);

            // Opcional: Destruye al zombi después de causar daño
            Destroy(other.gameObject);
        }
    }

    public void RecibirDanio(int cantidad)
    {
        vidaActual -= cantidad;
        UpdateHealthBar();

        // Asegúrate de que la vida no sea negativa
        if (vidaActual <= 0)
        {
            vidaActual = 0;
            FinDelJuego(); // Llama a la función de fin del juego
        }

    }
    void UpdateHealthBar()
    {
        if (healthBarFill != null)
        {
            healthBarFill.fillAmount = (float)vidaActual / vidaMaxima; ;
        }
        if (healthText != null)
        {
            healthText.text = $"{vidaActual} / {vidaMaxima}";
        }
    }

    void FinDelJuego()
    {
        Debug.Log("¡El castillo ha caído! Fin del juego.");

        // Puedes cargar una escena de "Game Over"
        SceneManager.LoadScene("GameOverScene");
    }
}
