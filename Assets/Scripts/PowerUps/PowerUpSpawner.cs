using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    public float respawnTime = 30f;

    public GameObject[] powerUps;

    float respawnTimer;
    GameObject entity;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (entity) return;

        respawnTimer -= Time.deltaTime;
        if (respawnTimer < 0)
        {
            Respawn();
        }
        
    }

    private void Respawn()
    {
        int index = Random.Range(0, powerUps.Length);
        entity = Instantiate(powerUps[index], transform);
        //entity.transform.position = transform.position;
    }

    public void setRespawnTime()
    {
        respawnTimer = respawnTime;
    }
}
