using UnityEngine;

public class ShootSound : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    private void Update()
    {
        if (Input.GetMouseButton(0)) 
        {
            if (!audioSource.isPlaying) 
            {
                audioSource.Play();
            }
        }
        else
        {
            if (audioSource.isPlaying) 
            {
                audioSource.Stop();
            }
        }
    }
}
