using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Path", menuName = "Path")]
public class PathSriptable : ScriptableObject
{
    public List<Vector3> Steps;
    public List<GameObject> Nodes;

    public void SetNodes()
    {
        if(Nodes.Count == Steps.Count)
            return;        
    }

    public void UpdatePositions()
    {
        foreach (var node in Nodes)
        {
            Steps[Nodes.IndexOf(node)] = node.transform.position;
        }
    }
}
