using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy type Config")]
public class EnemyType : ScriptableObject
{
    public GameObject enemyPrefab;
    public GameObject pathPrefab;
    public float moveSpeed = 2f;
    public bool isBoss = false;

    public GameObject GetEnemyPrefab() { return enemyPrefab; }

    public List<Transform> GetWayPoints()
    {
        var waveWayPoints = new List<Transform>();
        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }
        return waveWayPoints;
    }
    
    public float GetMoveSpeed() { return moveSpeed; }
}
