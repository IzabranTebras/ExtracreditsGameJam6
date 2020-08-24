using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerManager : MonoBehaviour
{
    public Transform[] spawnPoints;

    int currenMaxEnemies;
    int MAX_ENEMIES_EASY = 20;
    int MAX_ENEMIES_HARD = 150;

    public GameObject enemyPrefab;

    static float maxSpawnTime = 1f;
    static float minSpawnTime = 0.05f;
    static float variability = 0.2f; // % of variability to make a little random

    float timeMaxDiff = 600;     // max difficulty at 10 minutes (600 s)

    int enemyNumber;
    private float timer;

    void Start()
    {
        currenMaxEnemies = MAX_ENEMIES_EASY;
        timer = CalculateSpawnTime();
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            currenMaxEnemies = CalculateMaxEnemies();
            if (CanSpawn())
            {
                int index = Random.Range(0, spawnPoints.Length - 1);
                Vector3 position = spawnPoints[index].position;
                Instantiate(enemyPrefab, position, new Quaternion(0,0,0,0));
                enemyNumber++;
                timer = CalculateSpawnTime();
            }

        }
    }

    private float CalculateSpawnTime()
    {
        float timeElapsed = FindObjectOfType<HUDManager>().TimeElapsed;
        float spawnTime = Mathf.Lerp(maxSpawnTime, minSpawnTime, timeElapsed / timeMaxDiff);
        return Random.Range(spawnTime * (1 + variability), spawnTime * (1 - variability));
    }

    private int CalculateMaxEnemies()
    {
        float timeElapsed = FindObjectOfType<HUDManager>().TimeElapsed;
        return (int)Mathf.Lerp(MAX_ENEMIES_EASY, MAX_ENEMIES_HARD, timeElapsed / timeMaxDiff);
    }
    public void Reset()
    {
        currenMaxEnemies = 0;
    }

    private bool CanSpawn()
    {
        if (enemyNumber >= currenMaxEnemies) return false;

        return true;
    }
}
