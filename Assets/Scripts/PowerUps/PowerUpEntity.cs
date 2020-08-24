using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpEntity : MonoBehaviour
{
    public PowerUpManager.PowerUpID powerUpID;
    public float rotationSpeed = 25f;
    public ParticleSystem pickUpFX = null;
    public float timeToDestroyFX = 5.0f;
    public AudioSource pickUpSFX = null;

    private MeshRenderer _mesh = null;
    private Collider _coll = null;

    private void Update()
    {
        transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        _mesh = GetComponent<MeshRenderer>();
        _coll = GetComponent<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            pickUpSFX.Play();
            pickUpFX.transform.parent = null;
            pickUpFX.Play();
            Destroy(pickUpFX, timeToDestroyFX);

            FindObjectOfType<PowerUpManager>().PowerUpAction(powerUpID);
            GetComponentInParent<PowerUpSpawner>().setRespawnTime();

            _coll.enabled = false;
            _mesh.enabled = false;
            Destroy(gameObject, 2.0f);
        }

    }
}
