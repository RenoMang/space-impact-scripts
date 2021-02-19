using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltCollisionHandler : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        if (damageDealer.CompareTag("EnemyShot"))
        {
            //Debug.Log("Bolts collided");
            damageDealer.Hit();
            Destroy(gameObject);
        }
    }
}
