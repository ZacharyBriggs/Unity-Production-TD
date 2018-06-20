using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PayloadBehaviour : MonoBehaviour
{
    private int CurrentNode = 0;
    private int NextNode = 1;
    public PathSriptable Path;
    private NavMeshAgent Agent;
    public float HP = 100;
    // Use this for initialization
    void Start()
    {
        this.transform.position = Path.Steps[CurrentNode];
        Agent = GetComponent<NavMeshAgent>();
        Agent.destination = Path.Steps[NextNode];
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x == Path.Steps[NextNode].x && this.transform.position.z == Path.Steps[NextNode].z)
            ChangeDestination();
        if (Input.GetKeyDown(KeyCode.Space))
            HP -= 10;
        if (HP < 0)
            HP = 0;
    }

    void ChangeDestination()
    {
        CurrentNode = NextNode;
        NextNode += 1;
        Agent.destination = Path.Steps[NextNode];
    }
}
