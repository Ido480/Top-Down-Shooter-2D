using UnityEngine;

public class HealthCollectibleBehaviour : MonoBehaviour, ICollectibleBehaviour
{
    [SerializeField] private float healthAmount;
    public void OnCollected(GameObject player)
    {
        player.GetComponent<Health>().AddHealth(healthAmount);
    }
}
