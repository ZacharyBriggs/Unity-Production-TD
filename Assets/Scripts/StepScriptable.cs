using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Step")]
public class StepScriptable : ScriptableObject
{
    public Vector3 position;
    public bool IsWaveNode;
    public WaveScriptable Wave;
}
