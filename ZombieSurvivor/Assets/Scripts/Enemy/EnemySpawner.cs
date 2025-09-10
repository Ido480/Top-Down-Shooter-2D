using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float minimumSpawnTime;
    [SerializeField] private float maximumSpawnTime;
    private float timeUntilSpawn;
    private float currentMaxHealth = 10f;
    [SerializeField] private float healthIncreaseAmount = 10f;
    [SerializeField] private float healthIncreaseInterval = 10f;

    private void Awake()
    {
        SetTimeUntilSpawn();
    }

    private void Start()
    {
        InvokeRepeating(nameof(IncreaseMaxHealth), healthIncreaseInterval, healthIncreaseInterval);
    }

    private void IncreaseMaxHealth()
    {
        currentMaxHealth += healthIncreaseAmount;
    }

    private void Update()
    {
        timeUntilSpawn -= Time.deltaTime;

        if (timeUntilSpawn <= 0)
        {
            SpawnEnemy();
            SetTimeUntilSpawn();
        }
    }

    private void SpawnEnemy()
    {
        GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);

        // Set the enemy as a child of the spawner
        newEnemy.transform.SetParent(transform);

        newEnemy.transform.localPosition = Vector3.zero;

        // Set the enemy's health
        Health enemyHealth = newEnemy.GetComponent<Health>();
        if (enemyHealth != null)
        {
            enemyHealth.SetMaxHealth(currentMaxHealth); // Apply the updated max health to the enemy
        }
    }

    private void SetTimeUntilSpawn()
    {
        timeUntilSpawn = Random.Range(minimumSpawnTime, maximumSpawnTime);
    }
}
