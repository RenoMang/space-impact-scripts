using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class WaveConfig : ScriptableObject
{
    public GameObject enemyPrefab;
    public GameObject pathPrefab;
    public float timeBetweenSpawns = 0.5f;
    public float delayAfterWave = 1f;
    public int numberOfEnemies = 5;
    public float moveSpeed = 2f;

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
    
    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }
    
    public float GetDelayAfterWave() { return delayAfterWave; }

    public int GetNumberOfEnemies() { return numberOfEnemies; }
    
    public float GetMoveSpeed() { return moveSpeed; }
}
