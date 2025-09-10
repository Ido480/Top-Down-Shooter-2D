using UnityEngine;

public class Collectible : MonoBehaviour
{
    private ICollectibleBehaviour collectibleBehaviour;

    private void Awake()
    {
        collectibleBehaviour = GetComponent<ICollectibleBehaviour>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.GetComponent<PlayerController>();

        if (player != null )
        {
            collectibleBehaviour.OnCollected(player.gameObject);
            Destroy(gameObject);
        }
    }
}
