using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByTime : MonoBehaviour
{
    public float lifetime; // time before the explosion is destroyed
    void Start()
    {
        Destroy(gameObject, lifetime);
    }

}
