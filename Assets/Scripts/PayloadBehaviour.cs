using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PayloadBehaviour : MonoBehaviour
{
    //raise events when the payload does the following
    //stops, starts
    //ToDo: payload takes damage event
    [Header("Events")]
    public GameEvent OnPayLoadStopped;
    public GameEvent OnPayloadStart;
    [Space]
    public int Health;
    public bool Stopped;
    private HealthScriptable HealthScript;
    public PathSriptable Path;
    public int CurrentSpeed { get; set; }
    public int CurrentNode = 0;
    private int NextNode = 1;
    private NavMeshAgent Payload;
    

    public void StopPayload()
    {
        Payload.isStopped = true;
        OnPayLoadStopped.Raise();
    }
    
    public void StartPayload()
    {
        ChangeDestination();
        OnPayloadStart.Raise();
        Payload.isStopped = false;
    }

    // Use this for initialization
    private void Start()
    {
        HealthScript = ScriptableObject.CreateInstance<HealthScriptable>();
        HealthScript.Health = this.Health;
        this.transform.position = Path.Steps[0].position;
        Payload = GetComponent<NavMeshAgent>();
        Payload.destination = Path.Steps[1].position;
    }

    private int raiseCounter = 0;
    // Update is called once per frame
    private void Update()
    {

        Payload.speed = CurrentSpeed;
        this.Health = HealthScript.Health;
        if (Path == null)
            return;

        //ToDo: use mathf.approximately(float,float) for floating point comparison
        //if (this.transform.position.x == Path.Steps[NextNode].position.x
        //    && this.transform.position.z == Path.Steps[NextNode].position.z && CurrentNode + 2 < Path.Steps.Count)
        //    ChangeDestination();
        if (this.transform.position.x == Path.Steps[Path.Steps.Count - 1].position.x &&
                 this.transform.position.z == Path.Steps[Path.Steps.Count - 1].position.z)
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

    private void ChangeDestination()
    {
        CurrentNode = NextNode;
        NextNode += 1;
        Payload.SetDestination(Path.Steps[NextNode].position);

        //if (Path.Steps[CurrentNode].IsWaveNode)
        //{
        //    //SpawnWave();
        //}
    }



    public void TakeDamage(int amount)
    {
        HealthScript.TakeDamage(amount);
        if (HealthScript.Health <= 0)
            Destroy(this.gameObject);
    }

    private void Win()
    {
        Debug.Log("You Win!!!!");
        SceneManager.LoadScene("mainmenu");
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.tag == "Player" && Stopped == false)
    //        CurrentSpeed = 3;
    //    else if (Stopped)
    //        CurrentSpeed = 0;
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.gameObject.tag == "Player")
    //        CurrentSpeed = 0;
    //}

    
}
