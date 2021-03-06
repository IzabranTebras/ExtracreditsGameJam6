﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    static public int enemyNumber;
    static int currenMaxEnemies;
    static int MAX_ENEMIES_EASY = 20;
    static int MAX_ENEMIES_HARD = 150;

    public GameObject enemyPrefab;

    public static float maxSpawnTime = 15f;
    public static float minSpawnTime = 0.1f;
    public static float variability = 0.2f; // % of variability to make a little random

    static float timeMaxDiff = 600;     // max dificult at 10 minutes (600 s)

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
        if(timer < 0)
        {
            currenMaxEnemies = CalculateMaxEnemies();
            if (CanSpawn())
            {
                Instantiate(enemyPrefab, transform.position, transform.rotation);
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
        return (int) Mathf.Lerp(MAX_ENEMIES_EASY, MAX_ENEMIES_HARD, timeElapsed / timeMaxDiff);
    }
    public static void Reset()
    {
        currenMaxEnemies = 0;
    }

    private static bool CanSpawn()
    {
        if (enemyNumber >= currenMaxEnemies) return false;

        return true;
    }
}
