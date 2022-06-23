using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemies, powerups;
    private float spawnRange = 9.0f, startDelay = 1.0f, enemySpawnTime = 5.0f, powerupSpawnTime = 15.0f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, enemySpawnTime);
        InvokeRepeating("SpawnRandomPowerup", startDelay, powerupSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
          
    }

    void SpawnRandomEnemy()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0.5f, spawnPosZ);

        int randomIndex = Random.Range(0,enemies.Length);

        Instantiate(enemies[randomIndex], spawnPos, enemies[randomIndex].gameObject.transform.rotation);
    }

    void SpawnRandomPowerup()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 spawnPos = new Vector3(spawnPosX, 0.5f, spawnPosZ);

        int randomIndex = Random.Range(0, powerups.Length);

        Instantiate(powerups[randomIndex], spawnPos, powerups[randomIndex].gameObject.transform.rotation);
    }
}
