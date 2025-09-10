using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    public UnityEvent OnScoreChanged;
    public int Score { get; private set; }
    private int highScore;

    private void Awake()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    public void AddScore(int amount)
    {
        Score += amount;
        OnScoreChanged.Invoke();

        if (Score > highScore)
        {
            highScore = Score;
            PlayerPrefs.SetInt("HighScore", highScore); 
        }
    }

    public int GetHighScore()
    {
        return highScore;
    }
}
