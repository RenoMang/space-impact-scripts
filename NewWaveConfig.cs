using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "New Wave Config")]
public class NewWaveConfig : ScriptableObject
{
    public float delayAfterWave = 1f;
    public List<EnemyType> EnemyConfig;
    public List<float> TimeBetweenSpawns;

    public float GetDelayAfterWave() { return delayAfterWave; }

    public List<EnemyType> GetEnemyConfig() { return EnemyConfig; }

    public List<float> GetTimeBetweenSpawns() { return TimeBetweenSpawns; }
}
