using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public GameObject fruit;

    private float spawnRangeX = 12;
    private float spawnPosYLow = 1;
    private float spawnPosYHigh = 12;
    private float spawnPosZ = -1;

    private float fruitSpawnTime = 3.0f;
    private float startDelay = 1;
    private float spawnInterval = 1.0f;

    private float fruitSpawnRangeX = 6;
    private float fruitSpawnRangeLowY = 2;
    private float fruitSpawnRangeHighY = 12;

    private int fruitsOnScreen = 1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomEnemy", startDelay, spawnInterval);
        InvokeRepeating("SpawnFruits", startDelay, fruitSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnRandomEnemy()
    {
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);
        int leftOrRight = Random.Range(0, 2);

        if (enemyIndex == 0 && leftOrRight == 0)
        {
            Vector3 spawnPos = new Vector3(spawnRangeX, Random.Range(spawnPosYLow, spawnPosYHigh), spawnPosZ);
            Instantiate(enemyPrefabs[0], spawnPos, enemyPrefabs[0].transform.rotation);
        }
        if (enemyIndex == 0 && leftOrRight == 1)
        {
            Vector3 spawnPos = new Vector3(-spawnRangeX, Random.Range(spawnPosYLow, spawnPosYHigh), spawnPosZ);
            Instantiate(enemyPrefabs[0], spawnPos, enemyPrefabs[0].transform.rotation);
        }
        if (enemyIndex == 1)
        {
            Vector3 spawnPos = new Vector3(Random.Range(spawnRangeX, -spawnRangeX), spawnPosYHigh + 5, spawnPosZ);
            Instantiate(enemyPrefabs[1], spawnPos, enemyPrefabs[1].transform.rotation);
        }


    }
    void SpawnFruits()
    {
        float randomX = Random.Range(fruitSpawnRangeX, -fruitSpawnRangeX);
        float randomY = Random.Range(fruitSpawnRangeLowY, fruitSpawnRangeHighY);
        Vector3 spawnPos = new Vector3(randomX, randomY, spawnPosZ);

        Instantiate(fruit, spawnPos, fruit.gameObject.transform.rotation);
    }

}
