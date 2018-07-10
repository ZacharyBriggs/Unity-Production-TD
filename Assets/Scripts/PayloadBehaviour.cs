using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PayloadBehaviour : MonoBehaviour
{
    public int Health;
    private HealthScriptable HealthScript;
    public PathSriptable Path;

    private int CurrentNode = 0;
    private int NextNode = 1;
    private NavMeshAgent Payload;
    
    // Use this for initialization
    void Start()
    {
        HealthScript = ScriptableObject.CreateInstance<HealthScriptable>();
        HealthScript.Health = this.Health;
        this.transform.position = Path.Steps[0];
        Payload = GetComponent<NavMeshAgent>();
        Payload.destination = Path.Steps[1];
    }

    // Update is called once per frame
    void Update()
    {
        this.Health = HealthScript.Health;
        Payload.speed = 0;
        if(Path == null)
            return;
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
            this.TakeDamage(99999999);
        }
#endif
    }

    void ChangeDestination()
    {
        CurrentNode = NextNode;
        NextNode += 1;
        Payload.destination = Path.Steps[NextNode];
    }

    public void TakeDamage(int amount)
    {
        HealthScript.TakeDamage(amount);
        if (HealthScript.Health <= 0)
            Destroy(this.gameObject);
    }
    void Win()
    {
        Debug.Log("You Win!!!!");
        SceneManager.LoadScene("mainmenu");
    }

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
            Payload.speed = 3;
    }
}
