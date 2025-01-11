using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    void Start()
    {
        // Subscribe to the ScoreManager event
        ScoreManager.Instance.OnScoreChanged += UpdateScoreText;

        // Initialize text
        UpdateScoreText(ScoreManager.Instance.GetPoints());
    }

    void OnDestroy()
    {
        // Unsubscribe from the event when the object is destroyed
        ScoreManager.Instance.OnScoreChanged -= UpdateScoreText;
    }

    void UpdateScoreText(int points)
    {
        scoreText.text = "Points: " + points;
    }
}


