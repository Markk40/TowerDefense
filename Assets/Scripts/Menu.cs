using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject jugabilidadPanel;
    public GameObject instruccionesPanel;
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

    public void ActivarJugabilidad()
    {
        jugabilidadPanel.SetActive(true);
    }

    // Este método desactiva el panel de instrucciones
    public void DesactivarJugabilidad()
    {
        jugabilidadPanel.SetActive(false);
    }

    public void ActivarInstrucciones()
    {
        instruccionesPanel.SetActive(true);
    }

    // Este método desactiva el panel de instrucciones
    public void DesactivarInstrucciones()
    {
        instruccionesPanel.SetActive(false);
    }

}