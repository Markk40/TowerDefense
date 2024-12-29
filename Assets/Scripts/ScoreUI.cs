using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // Subscribirse al evento del ScoreManager
        ScoreManager.Instance.OnScoreChanged += UpdateScoreText;

        // Inicializar texto
        UpdateScoreText(ScoreManager.Instance.GetPoints());
    }

    void OnDestroy()
    {
        // Desuscribirse del evento cuando el objeto sea destruido
        ScoreManager.Instance.OnScoreChanged -= UpdateScoreText;
    }

    void UpdateScoreText(int puntos)
    {
        scoreText.text = "Points: " + puntos;
    }
}

