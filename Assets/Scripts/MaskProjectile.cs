using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MaskProjectile : MonoBehaviour
{
    [NonSerialized]
    public float speed = 0.0f;
    [NonSerialized]
    public float damage = 0.0f;

    private Rigidbody _rigid = null;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        _rigid.velocity = Vector3.zero;
        _rigid.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
