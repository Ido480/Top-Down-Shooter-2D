using UnityEngine;

public class EnemyCollectableDrop : MonoBehaviour
{
    [SerializeField] private float chanceOfCollectableDrop;

    private CollectableSpawner collectableSpawner;

    private void Awake()
    {
        collectableSpawner = Object.FindFirstObjectByType<CollectableSpawner>();
    }

    public void RandomlyDropCollectable()
    {
        float random = Random.Range(0,1f);
        if (chanceOfCollectableDrop >= random)
        {
            collectableSpawner.SpawnCollectable(transform.position);
        }
    }
}
