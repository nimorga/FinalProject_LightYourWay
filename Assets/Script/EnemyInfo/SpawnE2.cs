using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnE2 : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float spawnTime = 10f;   //Time between spawns
    public Transform[] spawnPoints = new Transform[3]; //3 Spawn points
    private float timerEnemy;

    void Start()
    {
        SpawnEnemy();
        timerEnemy = spawnTime;// 1sec per
    }

    void Update()
    {
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