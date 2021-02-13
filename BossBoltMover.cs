using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBoltMover : MonoBehaviour
{
    public float speed;
    //Rigidbody rb;

    private GameObject player;
    private Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
        //rb.velocity = transform.up * speed;
        if (GameObject.Find("Player"))
        {
            player = GameObject.Find("Player");
            targetPosition = player.transform.position;
        }
        else
            targetPosition = transform.position;
    }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (transform.position != targetPosition)
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed);
        else
            Destroy(this.gameObject);
    }
}
