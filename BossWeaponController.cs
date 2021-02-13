using UnityEngine;
using System.Collections;

public class BossWeaponController : MonoBehaviour
{

    public GameObject shot;
    public Transform shotSpawn1;
    public Transform shotSpawn2;
    public float fireRate;
    public float delay;

    public GameObject ray;
    public Transform shotSpawn3;
    public float rayfireRate;
    public float raydelay;


    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        InvokeRepeating("Fire", delay, fireRate);
        InvokeRepeating("FireRay", raydelay, rayfireRate);
    }

    void Fire()
    {
        float r = Random.value;
        if (r > 0.5)
            Instantiate(shot, shotSpawn1.position, shotSpawn1.rotation);
        else
            Instantiate(shot, shotSpawn2.position, shotSpawn2.rotation);
    }

    void FireRay()
    {
        Instantiate(ray, shotSpawn3.position, shotSpawn3.rotation);
    }
}