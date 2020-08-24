using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEntity : MonoBehaviour
{
    public PowerUpManager.PowerUpID powerUpID;
    public float rotationSpeed = 25f;
    public ParticleSystem pickUpFX = null;
    public float timeToDestroyFX = 5.0f;

    private void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            pickUpFX.transform.parent = null;
            pickUpFX.Play();
            Destroy(pickUpFX, timeToDestroyFX);

            FindObjectOfType<PowerUpManager>().PowerUpAction(powerUpID);
            GetComponentInParent<PowerUpSpawner>().setRespawnTime();
            Destroy(gameObject);
        }

    }
}
