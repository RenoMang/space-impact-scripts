using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    private PlayerController playerController;
    
    void Start()
    {
        playerController = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (playerController.GetHealth() == 3)
        {
            gameObject.SetActive(false);
        }
        
        else gameObject.SetActive(true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && playerController.GetHealth() != 3)
        {
            playerController.HealthUp();
            Destroy(gameObject);
        }
    }
}
