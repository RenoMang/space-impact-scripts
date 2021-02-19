﻿using System;
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

    private GameObject background;
    private Transform backgroundTransform;
    private HealthDisplay healthDisplay;
    private Rigidbody rigidBody;
    public float space;


    void Start()
    {

    }

    public override void Initialize()
    {
        _playerController = GetComponent<PlayerController>();
        background = GameObject.Find("Background");
        //backgroundTransform = background.transform;
        newEnemySpawner = GameObject.Find("EnemySpawner").GetComponent<NewEnemySpawner>();
        healthDisplay = FindObjectOfType<HealthDisplay>();
        rigidBody = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        //reset the background
        //background.transform.position = backgroundTransform.position;
        //background.transform.rotation = backgroundTransform.rotation;
        //background.transform.localScale = backgroundTransform.localScale;

        //reset the player
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        transform.rotation = Quaternion.Euler(0.0f, 90.0f, 0.0f);
        _playerController.health = 3;
        healthDisplay.life = 3;

        //reset the enemy
        newEnemySpawner.ResetEnemies();
        Debug.Log("Start");
    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Observe the agent's local rotation (3 observations)
        Debug.Log(transform.position.normalized);
        Debug.Log(_playerController.isDealTrigger ? 1 : 0);
        sensor.AddObservation(transform.position.normalized);
        sensor.AddObservation(_playerController.isDealTrigger ? 1 : 0);
    }

    public override void OnActionReceived(ActionBuffers actionBuffers)
    {
        Debug.Log(actionBuffers);
        int moveHorizontal = actionBuffers.DiscreteActions[1];
        int moveVertical = actionBuffers.DiscreteActions[2];
        int fire = actionBuffers.DiscreteActions[0];
        Debug.Log((moveHorizontal, moveVertical, fire));
        Vector3 movement = new Vector3(0, 0, 0);
        if (moveHorizontal == 1 || moveVertical == 1)
        {
            movement = new Vector3(moveHorizontal * space, 0.0f, moveVertical * space);
        }
        rigidBody.velocity = movement * _playerController.speed;
        rigidBody.position = new Vector3
        (
            Mathf.Clamp(rigidBody.position.x, _playerController.boundary.xMin, _playerController.boundary.xMax),
            0.0f,
            Mathf.Clamp(rigidBody.position.z, _playerController.boundary.zMin, _playerController.boundary.zMax)
        );
        rigidBody.rotation = Quaternion.Euler(0.0f, 90.0f, rigidBody.velocity.z * _playerController.tilt);

        if (fire == 1 && Time.time > _playerController.nextFire)
        {
            _playerController.nextFire = Time.time + _playerController.fireRate;
            Instantiate(_playerController.shot, _playerController.shotSpawn.position, _playerController.shot.transform.rotation); // Instantiates as a gameobject
        }
    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        Debug.Log(actionsOut);
        /*var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");*/

        var discreteActionsOut = actionsOut.DiscreteActions;
        if (Input.GetButton("Fire1"))
        {
            discreteActionsOut[0] = 1;
        }
        if (Input.GetButton("Horizontal"))
        {
            discreteActionsOut[1] = 1;
        }
        if (Input.GetButton("Vertical"))
        {
            discreteActionsOut[2] = 1;
        }
    }
}