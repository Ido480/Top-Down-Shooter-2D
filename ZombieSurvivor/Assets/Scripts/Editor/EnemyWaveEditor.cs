using UnityEditor;
using UnityEngine;

public class EnemyWaveEditor : EditorWindow
{
    [SerializeField] private GameObject enemyPrefab; 
    [SerializeField] private int enemiesPerWave = 5; 
    [SerializeField] private Vector2 minSpawnPosition = new Vector2(-10, -10); 
    [SerializeField] private Vector2 maxSpawnPosition = new Vector2(10, 10);   
    [SerializeField] private float waveDelay = 3f;   

    [MenuItem("My Tools/Enemy Wave Editor")]
    public static void ShowWindow()
    {
        GetWindow<EnemyWaveEditor>("Enemy Wave Editor");
    }

    void OnGUI()
    {
        GUILayout.Label("Enemy Wave Editor", EditorStyles.boldLabel);

        enemyPrefab = (GameObject)EditorGUILayout.ObjectField("Enemy Prefab", enemyPrefab, typeof(GameObject), true);
        enemiesPerWave = EditorGUILayout.IntField("Enemies Per Wave", enemiesPerWave);

        EditorGUILayout.LabelField("Spawn Area", EditorStyles.boldLabel);
        minSpawnPosition = EditorGUILayout.Vector2Field("Min Spawn Position", minSpawnPosition);
        maxSpawnPosition = EditorGUILayout.Vector2Field("Max Spawn Position", maxSpawnPosition);

        waveDelay = EditorGUILayout.FloatField("Wave Delay (seconds)", waveDelay);

        if (GUILayout.Button("Spawn Wave"))
        {
            SpawnWave();
        }

        if (GUILayout.Button("Clear Enemies"))
        {
            ClearEnemies();
        }
    }

    private void SpawnWave()
    {
        if (enemyPrefab == null)
        {
            Debug.LogWarning("Please assign an enemy prefab!");
            return;
        }

        for (int i = 0; i < enemiesPerWave; i++)
        {
            float randomX = Random.Range(minSpawnPosition.x, maxSpawnPosition.x);
            float randomY = Random.Range(minSpawnPosition.y, maxSpawnPosition.y);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);

            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        }

        Debug.Log($"Spawned {enemiesPerWave} enemies.");
    }

    private void ClearEnemies()
    {
        // Find all enemies in the scene and destroy them
        EnemyMovement[] enemies = Object.FindObjectsByType<EnemyMovement>(FindObjectsSortMode.None);

        foreach (var enemy in enemies)
        {
            DestroyImmediate(enemy.gameObject);
        }

        Debug.Log("Cleared all enemies.");
    }
}
