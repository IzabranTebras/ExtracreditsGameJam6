using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEntity : MonoBehaviour
{
    public PowerUpManager.PowerUpID powerUpID;
    public float rotationSpeed = 25f;


    private void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            FindObjectOfType<PowerUpManager>().PowerUpAction(powerUpID);
            GetComponentInParent<PowerUpSpawner>().setRespawnTime();
            Destroy(gameObject);
        }

    }
}
