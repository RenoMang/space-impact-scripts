using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}
public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidBody;
    private HealthDisplay healthDisplay;

    [Header("Player health")]
    public int health = 3;

    [Header("Player movement")]
    public float speed;
    public float tilt;
    public Boundary boundary;

    [Header("Player VFX")]
    public GameObject playerExplosion;
    private SkinnedMeshRenderer meshRenderer;
    private Material defaultMaterial;
    public Material flashMaterial;

    [Header("Player SFX")]
    public AudioSource weaponSound;
    public AudioSource healthSound;
    public AudioSource damageSound;

    [Header("Shot settings")]
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public float nextFire;

    public bool isDealTrigger;
    private PlayerAgent agent;



    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        healthDisplay = FindObjectOfType<HealthDisplay>();
        meshRenderer = GetComponent<SkinnedMeshRenderer>();

        defaultMaterial = meshRenderer.material;
        isDealTrigger = false;
        agent = GetComponent<PlayerAgent>();
    }
    private void Update()
    {
        Fire();
    }

    public int GetHealth()
    {
        return health;
    }

    public void HealthUp()
    {
        if (health < 3)
        {
            healthDisplay.AddHealth();
            health++;
            healthSound.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        if (isDealTrigger == false)
            ProcessHit(damageDealer);
        isDealTrigger = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isDealTrigger = false;
    }

    private void ProcessHit(DamageDealer damageDealer)
    {

        if (damageDealer.CompareTag("PlayerShot"))
        {
            return;
        }

        damageSound.Play();
        meshRenderer.material = flashMaterial;

        health -= damageDealer.GetDamage();
        healthDisplay.TakeDamage(1); // Subtracts one heart from the heartdisplay script
        agent.AddReward(-0.2f);
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
        else
        {
            Invoke("ResetMaterial", .1f);
        }
    }

    public void ResetMaterial()
    {
        meshRenderer.material = defaultMaterial;
    }

    private void Die()
    {
        //Instantiate(playerExplosion, transform.position, transform.rotation);
        //Debug.Log("Player has died");
        //FindObjectOfType<LevelController>().LoadGameOver(); // when player dies, the game over screen is loaded
        //Destroy(gameObject);
        agent.SetReward(-1f);
        agent.EndEpisode();
    }

    private void Fire()
    {
        if (Input.GetButton("Fire1") && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shot.transform.rotation); // Instantiates as a gameobject
            weaponSound.Play();
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rigidBody.velocity = movement * speed;
        rigidBody.position = new Vector3
        (
            Mathf.Clamp(rigidBody.position.x, boundary.xMin, boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidBody.position.z, boundary.zMin, boundary.zMax)
        );
        rigidBody.rotation = Quaternion.Euler(0.0f, 90.0f, rigidBody.velocity.z * tilt);
    }
}