using System;
using UnityEditor;
using UnityEngine;

public class ObjectSpawner : EditorWindow
{
    [SerializeField] private GameObject objectToSpawn;
    [SerializeField] private int numberOfObjectsToSpawn = 1;
    [SerializeField] private Vector2 minSpawnPosition = new Vector2(-10, -10); 
    [SerializeField] private Vector2 maxSpawnPosition = new Vector2(10, 10);

    [MenuItem("My Tools/Object Spawner")]
    public static void ShowWindow()
    {
        GetWindow<ObjectSpawner>("Object Spawner");
    }

    void OnGUI()
    {
        GUILayout.Label("Object Spawner", EditorStyles.boldLabel);
        objectToSpawn = (GameObject)EditorGUILayout.ObjectField("Prefab Object", objectToSpawn, typeof(GameObject), true);
        numberOfObjectsToSpawn = EditorGUILayout.IntField("Number Of Objects", numberOfObjectsToSpawn);

        EditorGUILayout.LabelField("Spawn Area", EditorStyles.boldLabel);
        minSpawnPosition = EditorGUILayout.Vector2Field("Min Spawn Position", minSpawnPosition);
        maxSpawnPosition = EditorGUILayout.Vector2Field("Max Spawn Position", maxSpawnPosition);

        if (GUILayout.Button("Spawn Object"))
        {
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        if (objectToSpawn == null)
        {
            Debug.LogWarning("Please select a prefab object to spawn");
            return;
        }

        for (int i = 0; i < numberOfObjectsToSpawn; i++)
        {
            float randomX = UnityEngine.Random.Range(minSpawnPosition.x, maxSpawnPosition.x);
            float randomY = UnityEngine.Random.Range(minSpawnPosition.y, maxSpawnPosition.y);
            Vector3 randomPosition = new Vector3(randomX, randomY, 0);

            Instantiate(objectToSpawn, randomPosition, Quaternion.identity);
        }
    }
}
