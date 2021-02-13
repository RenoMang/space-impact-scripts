using System;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents;
using Unity.MLAgents.Actuators;
using Unity.MLAgents.Sensors;
using UnityEngine;

public class PlayerAgent : Agent
{
    // Start is called before the first frame update
    private PlayerController _playerController;
    private NewEnemySpawner newEnemySpawner;
    //private  Enemy nearestEnemy ;
    //private   Enemy nearestBullet;

    private GameObject background;
    private Transform backgroundTransform;


    void Start()
    {

    }

    public override void Initialize()
    {
        _playerController = GetComponent<PlayerController>();
        background = GameObject.Find("Background");
        backgroundTransform = background.transform;
        newEnemySpawner = GetComponent<NewEnemySpawner>();
    }

    public override void OnEpisodeBegin()
    {
        //reset the background
        background.transform.position = backgroundTransform.position;
        background.transform.rotation = backgroundTransform.rotation;
        background.transform.localScale = backgroundTransform.localScale;

        //reset the player
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        _playerController.health = 3;

        //reset the enemy
        newEnemySpawner.ResetEnemies();
    }

    private void UpdateNearestBullet()
    {
        throw new NotImplementedException();
    }

    private void UpdateNearestEnemy()
    {
        foreach (Enemy enemy in flowerArea.Flowers)
        {
            if (nearestEnemy == null)
            {
                // No current nearest enemy r, so set to this enemy
                nearestEnemy = enemy;
            }
            else if (enemy)
            {
                // Calculate distance to this flower and distance to the current nearest flower
                float distanceToEnemy = Vector3.Distance(enemy.transform.position, transform.position);
                float distanceToCurrentNearestEnemy = Vector3.Distance(nearestenemy.transform.position, transform.position);

                // If current nearest enemy is empty OR this enemy is closer, update the nearest flower
                if (distanceToEnemy < distanceToCurrentNearestEnemy)
                {
                    nearestEnemy = enemy;
                }
            }
        }
    }
    public override void CollectObservations(VectorSensor sensor)
    {
        // Observe the agent's local rotation (2 observations)
        sensor.AddObservation(transform.position.normalized);
        //sensor.AddObservation(gameObject.transform.position.x);
        //sensor.AddObservation(gameObject.transform.position.z);

        // Get a vector from the agent to the nearest Enemy(2 observations)
        Vector3 toEnemy = nearestEnemy.transform.position - transform.position;
        sensor.AddObservation(toEnemy.normalized);

        // Get a vector from the agent to the nearest Bullet(2 observations)
        Vector3 toBullet = nearestBullet.transform.position - transform.position;
        sensor.AddObservation(toEnemy.normalized);


    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        var discreteActions = actionBuffers.DiscreteActions;
        // Get the action index for movement
        int movement = actionBuffers.DiscreteActions[0];
        // Get the action index for jumping
        int Shoot = actionBuffers.DiscreteActions[1];

        // Look up the index in the movement action list:
        if (movement == 1) { directionX = -1; }
        if (movement == 2) { directionX = 1; }
        if (movement == 3) { directionZ = -1; }
        if (movement == 4) { directionZ = 1; }
        // Look up the index in the jump action list:
        if (Shoot == 1) { directionY = 1; }

        // Apply the action results to move the Agent
        gameObject.GetComponent<Rigidbody>().AddForce(
            new Vector3(
                directionX * 40f, directionY * 300f, directionZ * 40f));


    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var discreteActionsOut = actionsOut.DiscreteActions;
        discreteActionsOut[0] = 0;
        if (Input.GetKey(KeyCode.D))
        {
            discreteActionsOut[0] = 3;
        }
        else if (Input.GetKey(KeyCode.W))
        {
            discreteActionsOut[0] = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            discreteActionsOut[0] = 4;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            discreteActionsOut[0] = 2;
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            discreteActionsOut[0] = 5;
        }
    }
}