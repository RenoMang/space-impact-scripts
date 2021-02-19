using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipController : MonoBehaviour
{
    Rigidbody rigidBody;
    GameController gameController;

    [Header("Enemy Stats")]
    [SerializeField] float health = 1;
    [SerializeField] int scoreValue = 10;
    // public float speed;

    [Header("Enemy VFX")]
    public GameObject explosion;
    private PlayerAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        gameController = FindObjectOfType<GameController>();
        rigidBody = GetComponent<Rigidbody>();
        agent = FindObjectOfType<PlayerController>().GetComponent<PlayerAgent>();
        // rigidBody.velocity = transform.forward * speed;
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

        if (damageDealer.CompareTag("EnemyShot"))
        {
            return;
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
        //Debug.Log("Enemy has died");
        agent.AddReward(0.1f);
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
    }


}
