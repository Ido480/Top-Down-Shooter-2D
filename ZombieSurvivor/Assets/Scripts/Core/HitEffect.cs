using UnityEngine;

public class HitEffect : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, GetComponent<ParticleSystem>().main.duration);
    }
}
