using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject gameplayPanel;
    public GameObject instructionsPanel;

    public void ChangeScene(string gameScene)
    {
        SceneManager.LoadScene(gameScene);
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
