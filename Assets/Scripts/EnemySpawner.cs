using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    static public int enemyNumber;
    static int MAX_ENEMIES = 50;
    public GameObject enemyPrefab;

    public static float maxSpawnTime = 20f;
    public static float minSpawnTime = 5f;
    private float timer;

    void Start()
    {
        timer = Random.Range(maxSpawnTime, minSpawnTime);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if(timer < 0)
        {
            if(enemyNumber<MAX_ENEMIES)
            {
                Instantiate(enemyPrefab, transform.position, transform.rotation);
                enemyNumber++;
                timer = Random.Range(maxSpawnTime, minSpawnTime);
            }

        }
    }
}
