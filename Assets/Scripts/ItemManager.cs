using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    
    public float spawnPosZ = 30.0f;
    
    public float minSpawnPosY = 0.75f;
    public float maxSpawnPosY = 2.25f;

    public float minSpawnPosX = -3.5f;
    public float maxSpawnPosX = 3.5f;

    public float startDelay = 3;
    public float spawnInterval = 1f;

    public GameObject[] collectiblePrefabs;
    public int collectibleIndex;

    void Start() {
    
        InvokeRepeating("SpawnCollectibles", startDelay, spawnInterval);
    
    }

    void Update()
    {

    }

    void SpawnCollectibles() {
    
        int chance = Random.Range(0, 100);

        float xRange = Random.Range(minSpawnPosX, maxSpawnPosX);
        float yRange = Random.Range(minSpawnPosY, maxSpawnPosY);

        if(chance > 75) {
        
            int collectibleIndex = Random.Range(0, collectiblePrefabs.Length);
            Vector3 spawnPos = new Vector3(xRange, yRange, spawnPosZ);

            Instantiate(collectiblePrefabs[collectibleIndex], spawnPos, collectiblePrefabs[collectibleIndex].transform.rotation);
        
        }

    }
}
