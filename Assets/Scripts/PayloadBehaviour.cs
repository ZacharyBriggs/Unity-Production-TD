using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PayloadBehaviour : MonoBehaviour
{
    private int CurrentNode = 0;
    private int NextNode = 1;
    public List<Transform> NavNodes;
    private NavMeshAgent Agent;
    public float HP = 100;
    // Use this for initialization
    void Start()
    {
        this.transform.position = NavNodes[CurrentNode].position;
        Agent = GetComponent<NavMeshAgent>();
        Agent.destination = NavNodes[NextNode].position;
    }

    // Update is called once per frame
    void Update()
    {
        if(this.transform.position.x == NavNodes[NextNode].position.x && this.transform.position.y == NavNodes[NextNode].position.z)
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
        Agent.destination = NavNodes[NextNode].position;
    }
}
