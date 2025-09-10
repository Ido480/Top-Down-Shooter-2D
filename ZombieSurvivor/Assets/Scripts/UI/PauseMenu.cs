using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;

    private void Awake()
    {
        pauseScreen.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseScreen.activeInHierarchy)
            {
                PauseGame(false);
            }
            else
            {
                PauseGame(true);
            }
        }
    }

    public void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);

        if (status)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void Restart()
    {
        Time.timeScale = 1;  
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex
        );
    }

    public void MainMenu()
    {
        Time.timeScale = 1;  
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void SoundVolume()
    {
        float currentVolume = SoundManager.Instance.shootingSoundSource.volume;
        float newVolume = (currentVolume >= 1.0f) ? 0.0f : currentVolume + 0.1f;

        SoundManager.Instance.ChangeSoundVolume(newVolume);
        SoundManager.Instance.PlayShootingSound();
    }

    public void MusicVolume()
    {
        float currentVolume = SoundManager.Instance.backgroundMusicSource.volume;
        float newVolume = (currentVolume >= 1.0f) ? 0.0f : currentVolume + 0.1f;

        SoundManager.Instance.ChangeMusicVolume(newVolume);
    }
}
