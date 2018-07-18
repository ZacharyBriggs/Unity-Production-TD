using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManagerBehaviour : MonoBehaviour
{
    public GameObject EnemyPrefab;
    public WaveScriptable WaveInfo;

    public bool Active;
    public void SpawnWave()
    {
        if (Active)
            return;
        Active = true;
        for (int i = 0; i < WaveInfo.MaxEnemies; i++)
        {
            var e = Instantiate(EnemyPrefab, WaveInfo.EnemySpawnPositions[i], Quaternion.identity);
        }

    }
    public int DeathCount = 0;
    public void OnEnemyDied()
    {
        DeathCount++;
        if (DeathCount >= WaveInfo.MaxEnemies)
        {
            OnWaveComplete.Raise();
        }
    }
    public GameEvent OnWaveComplete;
}
