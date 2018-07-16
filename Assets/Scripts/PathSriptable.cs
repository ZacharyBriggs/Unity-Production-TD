using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Path", menuName = "Path")]
public class PathSriptable : ScriptableObject
{
    public List<StepScriptable> Steps;
}
