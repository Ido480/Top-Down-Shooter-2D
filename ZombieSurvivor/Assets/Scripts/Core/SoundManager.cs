using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] public AudioSource backgroundMusicSource;
    [SerializeField] public AudioSource shootingSoundSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayBackgroundMusic()
    {
        if (backgroundMusicSource != null && !backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.loop = true;
            backgroundMusicSource.Play();
        }
    }

    public void StopBackgroundMusic()
    {
        if (backgroundMusicSource != null && backgroundMusicSource.isPlaying)
        {
            backgroundMusicSource.Stop();
        }
    }

    public void PlayShootingSound()
    {
        if (shootingSoundSource != null)
        {
            shootingSoundSource.Play();
        }
    }

    public void ChangeMusicVolume(float volume)
    {
        volume = Mathf.Clamp01(volume);
        backgroundMusicSource.volume = volume;
    }


    public void ChangeSoundVolume(float volume)
    {
        if (shootingSoundSource != null)
        {
            shootingSoundSource.volume = Mathf.Clamp01(volume); 
        }
    }
}
