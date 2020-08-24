using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEntity : MonoBehaviour
{
    public PowerUpManager.PowerUpID powerUpID;
    public float respawnTime = 30f;
    float respawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        respawnTimer -= Time.deltaTime;
        if(respawnTimer<0)
        {
            Respawn();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            FindObjectOfType<PowerUpManager>().PowerUpAction(powerUpID);
            gameObject.SetActive(false);
            respawnTimer = respawnTime;
        }

    }

    private void Respawn()
    {
        powerUpID = (PowerUpManager.PowerUpID) Random.Range((int)PowerUpManager.PowerUpID.Normal, (int)PowerUpManager.PowerUpID.Speed);
        gameObject.SetActive(true);
    }
}
