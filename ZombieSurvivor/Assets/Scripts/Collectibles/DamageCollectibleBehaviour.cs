using UnityEngine;

public class DamageCollectibleBehaviour : MonoBehaviour, ICollectibleBehaviour
{
    [SerializeField] private float damageIncrease = 5f;

    public void OnCollected(GameObject player)
    {
        var bullet = player.GetComponent<PlayerShooting>();

        if (bullet != null)
        {
            bullet.IncreaseBulletDamage(damageIncrease);
        }
    }
}
