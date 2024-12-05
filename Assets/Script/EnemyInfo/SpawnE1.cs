using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Spawn enemies for level 2
public class SpawnE1 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime = 1f;   //Time between spawns
    public Transform[] spawnPoints = new Transform[3]; //3 Spawn points
    private float timerEnemy;

    void Start()
    {   
        SpawnEnemy();
        timerEnemy = spawnTime;//1sec per
    }

    void Update()
    {

        if (enemyPrefab == null)
        {
            Debug.LogWarning("Enemy prefab is missing or destroyed.");
            return;
        }
        timerEnemy -= Time.deltaTime;//time - timepassed
        if (timerEnemy <= 0f)
        {
            SpawnEnemy();
            timerEnemy = spawnTime;
        }
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);  //Choose 1 of 3 points
        Transform spawnPoint = spawnPoints[spawnIndex]; 

        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);//Spawn
    }
}

