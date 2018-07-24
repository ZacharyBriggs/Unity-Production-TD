using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveManagerBehaviour : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public WaveScriptable WaveInfo;
    public GameEvent CounterIncrement;
    public bool Active;
    public void SpawnWave()
    {
        if (Active)
            return;
        Active = true;
        for (int i = 0; i < WaveInfo.MaxEnemies; i++)
        {
            var e = Instantiate(EnemyPrefab, WaveInfo.EnemySpawnPositions[i], Quaternion.identity);
            e.GetComponent<EnemyBehaviour>().OnEnemyDied.AddListener(OnEnemyDied);
        }

    }
    public int DeathCount = 0;
    public void OnEnemyDied()
    {
        DeathCount++;
        CounterIncrement.Raise();
        if (DeathCount >= WaveInfo.MaxEnemies)
        {
            OnWaveComplete.Raise();
        }
    }
    public GameEvent OnWaveComplete;
}
