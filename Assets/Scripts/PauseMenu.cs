using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI; // El menú de pausa (asegúrate de configurarlo en el inspector)
    private bool isPaused = false;

    void Update()
    {
        // Detectar si se pulsa la tecla de pausa (por defecto, Escape)
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false); // Ocultar el menú de pausa
        Time.timeScale = 1f; // Restaurar el tiempo normal
        isPaused = false;
    }

    public void PauseGame()
    {
        pauseMenuUI.SetActive(true); // Mostrar el menú de pausa
        Time.timeScale = 0f; // Detener el tiempo
        isPaused = true;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // Asegurarse de que el tiempo vuelva a la normalidad antes de salir
        SceneManager.LoadScene("StartingScene"); // Cambiar a la escena del menú principal
    }
}

