using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemySpawner : MonoBehaviour
{
    public List<NewWaveConfig> waveConfigs;
    public int startingWave = 0;
    public float startWait = 1f;

    private GameObject[] enemies;
    private GameObject[] enemiesShot;

    void Start()
    {
        StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves()
    {
        yield return new WaitForSeconds(startWait);
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
            yield return new WaitForSeconds(currentWave.GetDelayAfterWave());
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(NewWaveConfig waveConfig)
    {
        List<EnemyType> EnemyConfig = waveConfig.GetEnemyConfig();
        for (int enemyCount = 0; enemyCount < EnemyConfig.Count; enemyCount++)
        {
            if (waveConfig.TimeBetweenSpawns[enemyCount] > 0)
                yield return new WaitForSeconds(waveConfig.TimeBetweenSpawns[enemyCount]);

            EnemyType enemyType = EnemyConfig[enemyCount];
            var newEnemy = Instantiate(
                enemyType.GetEnemyPrefab(),
                enemyType.GetWayPoints()[0].transform.position,
                Quaternion.Euler(0, -90, 0));

            if (enemyType.isBoss)
            {
                newEnemy.GetComponent<BossPathing>().SetWaveConfig(enemyType);
            }
            else newEnemy.GetComponent<NewEnemyPathing>().SetWaveConfig(enemyType);
        }
    }

    public void ResetEnemies()
    {
        //destroy all the enemies in the scene
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        enemiesShot = GameObject.FindGameObjectsWithTag("EnemyShot");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        foreach (GameObject enemyShot in enemiesShot)
        {
            Destroy(enemyShot);
        }
        StopAllCoroutines();
        StartCoroutine(SpawnAllWaves());
    }
}
