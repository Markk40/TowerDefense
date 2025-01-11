using System;
using TMPro;

public class ScoreManager
{
    private static ScoreManager instance; // Singleton instance
    private int points;
    public TextMeshProUGUI pointsText;

    // Event to notify point changes
    public event Action<int> OnScoreChanged;

    // Private constructor for Singleton
    private ScoreManager()
    {
        points = 190; // Initialize points
    }

    // Method to get the instance
    public static ScoreManager Instance
    {
        get
        {
            if (instance == null)
                instance = new ScoreManager();
            return instance;
        }
    }

    // Method to add points
    public void AddPoints(int amount)
    {
        points += amount;
        OnScoreChanged?.Invoke(points); // Notify change
    }

    // Method to spend points
    public bool SpendPoints(int amount)
    {
        if (points >= amount)
        {
            points -= amount;
            OnScoreChanged?.Invoke(points); // Notify change
            return true;
        }

        return false; // Not enough points
    }

    // Method to get current points
    public int GetPoints()
    {
        return points;
    }
}
