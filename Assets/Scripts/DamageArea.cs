using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    public int damage = 1;
    bool damageEnabled = true;

    float timer;
    float damageTime = 0.2f;

    private void Update()
    {
        if(!damageEnabled)
        {
            timer += Time.deltaTime;
            if(timer>damageTime)
            {
                damageEnabled = true;
                timer = 0;
            }
        }
    }
    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.layer == 10)
        {
            if(damageEnabled)
            {
               collision.gameObject.GetComponent<StatusScript>().TakeDamage(damage);
               damageEnabled = false;
            }
        }
    }
}
