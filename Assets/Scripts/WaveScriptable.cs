using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Wave")]
public class WaveScriptable : ScriptableObject
{
    public int MaxEnemies;
    public int CurrentEnemies;
    public List<Vector3> EnemySpawnPositions;
}
