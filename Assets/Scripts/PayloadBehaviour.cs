using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PayloadBehaviour : MonoBehaviour
{
    public int Health;
    public HealthScriptable HealthScriptable;
    public PathSriptable Path;

    private int CurrentNode = 0;
    private int NextNode = 1;
    private NavMeshAgent Agent;
    private NavMeshAgent Payload;
    
    // Use this for initialization
    void Start()
    {
        HealthScriptable.Health = this.Health;
        this.transform.position = Path.Steps[CurrentNode];
        Agent = GetComponent<NavMeshAgent>();
        Agent.destination = Path.Steps[NextNode];
        Payload = GetComponent<NavMeshAgent>();
        foreach (var node in Path.Nodes)
        {
            node.GetComponent<MeshRenderer>().enabled = false;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        this.Health = HealthScriptable.Health;
        Payload.speed = 0;
        if (this.transform.position.x == Path.Steps[NextNode].x && this.transform.position.z == Path.Steps[NextNode].z && CurrentNode + 2 < Path.Steps.Count)
            ChangeDestination();
        else if (this.transform.position.x == Path.Steps[Path.Steps.Count - 1].x &&
                 this.transform.position.z == Path.Steps[Path.Steps.Count - 1].z)
        {
            Win();
        }
#if UNITY_EDITOR
        if (Input.GetKeyDown(KeyCode.Space))
        {
            this.Die();
        }
#endif
    }

    void ChangeDestination()
    {
        CurrentNode = NextNode;
        NextNode += 1;
        Agent.destination = Path.Steps[NextNode];
    }

    void Win()
    {
        Debug.Log("You Win!!!!");
        SceneManager.LoadScene("mainmenu");
    }

    public void Die()
    {
        //isdead = true
        SceneManager.LoadScene("mainmenu");
        Destroy(this.gameObject);
    }
    [ContextMenu("Set Up Nodes")]
    void SetUpNodes()
    {
        Path.SetNodes();
        foreach (var step in Path.Steps)
        {
            var obj = GameObject.CreatePrimitive(PrimitiveType.Cube);
            obj.transform.position = step;
            Path.Nodes.Add(obj);
        }
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
            Payload.speed = 3;
    }

    void OnDrawGizmos()
    {
        while (Path.Nodes.Count < Path.Steps.Count)
        {
            Path.Nodes.Remove(Path.Nodes[Path.Nodes.Count - 1]);
        }
        Path.UpdatePositions();
    }

}
