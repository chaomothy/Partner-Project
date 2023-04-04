using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    
    public float spawnPosZ = 30.0f;
    public float spawnPosY = 4.5f;
    public int spawnPosX = 0;

    public float startDelay = 3;
    public float spawnInterval = 1f;

    public GameObject[] obstaclePrefabs;
    public int obstacleIndex;

    void Start() {
    
        InvokeRepeating("SpawnObstacles", startDelay, spawnInterval);
    
    }

    void Update()
    {

    }

    void SpawnObstacles() {
    
        int chance = Random.Range(1, 100);

        if(chance > 5) {
        
            int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
            Vector3 spawnPos = new Vector3(spawnPosX, obstaclePrefabs[obstacleIndex].transform.position.y, spawnPosZ);

            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
        
        }
    }
}
