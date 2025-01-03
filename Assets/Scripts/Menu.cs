using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject jugabilidadPanel;
    public GameObject instruccionesPanel;
    // Este m�todo cambia a la escena del juego
    public void IniciarJuego(string EscenaJuego)
    {
        // Aseg�rate de usar el nombre exacto de la escena en el m�todo LoadScene
        SceneManager.LoadScene(EscenaJuego);// Cambia "NombreDeLaEscenaDelJuego" por el nombre real
        Debug.Log("Se cambio la escena del juego");
    }

    // Este m�todo cierra la aplicaci�n
    public void SalirDelJuego()
    {
        Application.Quit(); // Esto cerrar� la aplicaci�n cuando est� construida
        Debug.Log("Se cerro el juego");
    }

    public void ActivarJugabilidad()
    {
        jugabilidadPanel.SetActive(true);
    }

    // Este m�todo desactiva el panel de instrucciones
    public void DesactivarJugabilidad()
    {
        jugabilidadPanel.SetActive(false);
    }

    public void ActivarInstrucciones()
    {
        instruccionesPanel.SetActive(true);
    }

    // Este m�todo desactiva el panel de instrucciones
    public void DesactivarInstrucciones()
    {
        instruccionesPanel.SetActive(false);
    }

}