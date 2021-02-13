using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    public int damage = 1;

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        //Debug.Log(gameObject.name);
        if (gameObject.name != "BossRayBolt(Clone)")
            Destroy(gameObject);
    }
}
