using DG.Tweening;
using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MaskProjectile : MonoBehaviour
{
    public float timeToDestroy = 4.0f;

    [NonSerialized]
    public float speed = 0.0f;
    [NonSerialized]
    public int damage = 0;

    private Rigidbody _rigid = null;
    private Tween _lifeTween = null;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody>();

        _lifeTween = DOVirtual.DelayedCall(timeToDestroy, () => Destroy(gameObject));
    }

    private void Update()
    {
        _rigid.velocity = Vector3.zero;
        _rigid.AddForce(transform.forward * speed, ForceMode.Impulse);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
        {
            other.GetComponent<StatusScript>().TakeDamage(damage);
        }

        _lifeTween.Kill();
        Destroy(gameObject);
    }
}
