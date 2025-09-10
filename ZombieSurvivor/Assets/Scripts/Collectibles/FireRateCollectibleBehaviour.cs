using UnityEngine;

public class FireRateCollectibleBehaviour : MonoBehaviour, ICollectibleBehaviour
{
    [SerializeField] private float fireRateBoost = 0.05f; 

    public void OnCollected(GameObject player)
    {
        var playerShooting = player.GetComponent<PlayerShooting>();

        if (playerShooting != null)
        {
            playerShooting.IncreaseFireRate(fireRateBoost);
        }
    }
}
