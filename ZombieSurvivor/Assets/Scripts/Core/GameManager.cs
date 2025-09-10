using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float timeToWaitBeforeExit;
    [SerializeField] private SceneController sceneController;
    [SerializeField] private ScoreController scoreController; 

    public void OnPlayerDied()
    {
        int currentHighScore = PlayerPrefs.GetInt("HighScore", 0);
        if (scoreController.Score > currentHighScore)
        {
            PlayerPrefs.SetInt("HighScore", scoreController.Score);
            PlayerPrefs.Save(); // Save the new high score
        }

        Invoke(nameof(EndGame), timeToWaitBeforeExit);
    }

    private void EndGame()
    {
        sceneController.LoadScene("Main Menu");
    }
}
