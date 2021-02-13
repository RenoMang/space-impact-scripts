using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPathing : MonoBehaviour
{
    EnemyType enemyType;
    private List<Transform> waypoints;
    private int waypointIndex = 0;


    void Start()
    {
        waypoints = enemyType.GetWayPoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    void Update()
    {
        Move();
    }

    public void SetWaveConfig(EnemyType enemyType)
    {
        this.enemyType = enemyType;
    }

    private void Move()
    {
        if (waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            var movementThisFrame = enemyType.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition)
            {
                if (waypointIndex == waypoints.Count - 1)
                {
                    waypointIndex--;
                }
                else waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
