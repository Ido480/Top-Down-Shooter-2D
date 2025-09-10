using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    private TMP_Text scoreText;
    private TMP_Text highScoreText;

    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
        highScoreText = transform.Find("HighScoreText").GetComponent<TMP_Text>(); 

        if (highScoreText == null)
        {
            Debug.LogError("HighScoreText not found!");
        }

        UpdateHighScoreUI();
    }

    public void UpdateScore(ScoreController scoreController)
    {
        scoreText.text = $"Score: {scoreController.Score}";
    }

    public void UpdateHighScoreUI()
    {
        int highScore = PlayerPrefs.GetInt("HighScore", 0); 
        highScoreText.text = $"High Score: {highScore}";
    }
}
