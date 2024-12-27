using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Este método cambia a la escena del juego
    public void IniciarJuego(string EscenaJuego)
    {
        // Asegúrate de usar el nombre exacto de la escena en el método LoadScene
        SceneManager.LoadScene(EscenaJuego);// Cambia "NombreDeLaEscenaDelJuego" por el nombre real
        Debug.Log("Se cambio la escena del juego");
    }

    // Este método cierra la aplicación
    public void SalirDelJuego()
    {
        Application.Quit(); // Esto cerrará la aplicación cuando esté construida
        Debug.Log("Se cerro el juego");
    }
}