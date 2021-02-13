using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BossController : MonoBehaviour
{
    Rigidbody rigidBody;
    GameController gameController;

    [Header("Enemy Stats")]
    [SerializeField] float health = 1;
    [SerializeField] int scoreValue = 10;

    [Header("Enemy VFX")]
    public GameObject explosion;

    private SkinnedMeshRenderer meshRenderer;
    private Material defaultMaterial;
    public Material flashMaterial;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        rigidBody = GetComponent<Rigidbody>();
        meshRenderer = GetComponent<SkinnedMeshRenderer>();

        defaultMaterial = meshRenderer.material;
    }

    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        if (damageDealer.CompareTag("Enemy"))
        {
            return;
        }
        
        if (damageDealer.CompareTag("EnemyShot") )
        {
            return;
        }

        meshRenderer.material = flashMaterial;
        
        gameController.AddToScore(scoreValue);
        health -= damageDealer.GetDamage();
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
        Debug.Log("Enemy has died");
        FindObjectOfType<LevelController>().LoadWinGame();
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
    }


}
