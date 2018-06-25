using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Path", menuName = "Health")]
public class PathSriptable : ScriptableObject
{
    public List<Vector3> Steps;
    public List<GameObject> Nodes;

    public void SetNodes()
    {
        if(Nodes.Count == Steps.Count)
            return;
        foreach (var step in Steps)
        {
            GameObject newObj = new GameObject();
            newObj.transform.position = step;
            Nodes.Add(newObj);
        }
    }

    public void UpdatePositions()
    {
        for (int i = 0; i < Nodes.Count; i++)
        {
            Steps[i] = Nodes[i].transform.position;
        }
    }
}
