using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject gameplayPanel;
    public GameObject instructionsPanel;

    public void StartGame(string gameScene)
    {
        SceneManager.LoadScene(gameScene);
        Debug.Log("Scene changed to the game");
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game closed");
    }

    public void ShowGameplay()
    {
        gameplayPanel.SetActive(true);
    }

    public void HideGameplay()
    {
        gameplayPanel.SetActive(false);
    }

    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void HideInstructions()
    {
        instructionsPanel.SetActive(false);
    }
}
