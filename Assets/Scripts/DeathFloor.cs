using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathFloor : MonoBehaviour
{

    public int damage = 9999;

    private void OnTriggerEnter(Collider other)
    {
        StatusScript status = other.GetComponent<StatusScript>();
        if(status)
        { 
            status.TakeDamage(damage);
        }


    }

}
