using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody rigidBody;
    GameController gameController;
    
    [Header("Enemy Stats")]
    [SerializeField] float health = 1;
    [SerializeField] int scoreValue = 10;
    public float speed;
    
    [Header("Enemy VFX")]
    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>(); 
        rigidBody = GetComponent<Rigidbody>();
        rigidBody.velocity = transform.right * speed;
    }
    
    private void OnTriggerEnter(Collider other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer) { return; }
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        if (damageDealer.CompareTag("Enemy") )
        {
            return;
        }
        
        if (damageDealer.CompareTag("EnemyShot") )
        {
            return;
        }
        
        if (damageDealer.CompareTag("Player") )
        {
            Instantiate(explosion, transform.position, transform.rotation);
        }
        
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            gameController.AddToScore(scoreValue);
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy has died");
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
    }
    
    
}
