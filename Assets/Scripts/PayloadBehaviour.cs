using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PayloadBehaviour : MonoBehaviour
{
    public PathSriptable Path;
    public float Radius;

    private int CurrentNode = 0;
    private int NextNode = 1;
    private NavMeshAgent Agent;
    private NavMeshAgent Payload;
    private SphereCollider Sphere;
    
    // Use this for initialization
    void Start()
    {
        this.transform.position = Path.Steps[CurrentNode];
        Agent = GetComponent<NavMeshAgent>();
        Agent.destination = Path.Steps[NextNode];
        Payload = GetComponent<NavMeshAgent>();
        Sphere = GetComponent<SphereCollider>();
        Sphere.radius = Radius;
    }

    // Update is called once per frame
    void Update()
    {
        Payload.speed = 0;
        if (this.transform.position.x == Path.Steps[NextNode].x && this.transform.position.z == Path.Steps[NextNode].z && CurrentNode + 2 < Path.Steps.Count)
            ChangeDestination();
    }

    void ChangeDestination()
    {
        CurrentNode = NextNode;
        NextNode += 1;
        Agent.destination = Path.Steps[NextNode];
    }

    void OnDrawGizmos()
    {
        Path.SetNodes();
        foreach (var step in Path.Steps)
        {
            Gizmos.DrawCube(step, new Vector3(1, 1, 1));
        }
        Path.UpdatePositions();
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
            Payload.speed = 3;
    }

}
