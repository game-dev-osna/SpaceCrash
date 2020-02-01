using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    private int initialAsteroidAmount;

    [SerializeField]
    private float secondsBetweenSpawn;
    
    [SerializeField]
    private GameObject[] asteroidPrefabs;

    [SerializeField]
    private GameObject sphereSpawn;

    [SerializeField]
    private GameObject sphereTarget;

    private Vector3[] spawnLocations;
    private Vector3[] targetLocations;

    System.Random random;
    float timer;

    void Start()
    {
        // get spawn positions
        var spawnPoints = sphereSpawn.GetComponent<MeshFilter>().mesh.vertices;      
        spawnLocations = new Vector3[spawnPoints.Length];
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            spawnLocations[i] = sphereSpawn.transform.TransformPoint(spawnPoints[i]);
        }
        sphereSpawn.SetActive(false);

        // get target positions
        var targetPoints = sphereTarget.GetComponent<MeshFilter>().mesh.vertices;
        targetLocations = new Vector3[spawnPoints.Length];
        for (int i = 0; i < targetPoints.Length; i++)
        {
            targetLocations[i] = sphereTarget.transform.TransformPoint(targetPoints[i]);
        }
        sphereTarget.SetActive(false);

        random = new System.Random();
        timer = 0f;
        InitialSpawn(initialAsteroidAmount);
    }

    
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= secondsBetweenSpawn)
        {
            Spawn();
            timer = 0;            
        }
    }

    void InitialSpawn(int amount)
    {
        for(int i = 0; i < amount; i++)
        {
            Spawn();
        }
    }

    void Spawn()
    {
       
        int asteroidIndex = random.Next(0, asteroidPrefabs.Length);
        int spawnIndex = random.Next(0, spawnLocations.Length);
        int targetIndex = random.Next(0, targetLocations.Length);

        var asteroid = GameObject.Instantiate(asteroidPrefabs[asteroidIndex], spawnLocations[spawnIndex], Quaternion.identity);
        asteroid.transform.LookAt(targetLocations[targetIndex], Vector3.up);        
    }
}
