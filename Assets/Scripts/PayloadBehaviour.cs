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
    public GameEvent OnTakeDamage;
    public GameEvent OnPaylodDied;
    [Space]
    public int Health;
    public bool Stopped;
    private HealthScriptable _healthScript;
    public PathSriptable Path;
    private int CurrentSpeed { get; set; }
    public int CurrentNode = 0;
    private int NextNode = 1;
    private NavMeshAgent _payload;
    

    public void StopPayload()
    {
        _payload.isStopped = true;
        OnPayLoadStopped.Raise();
    }
    
    public void StartPayload()
    {
        ChangeDestination();
        OnPayloadStart.Raise();
        _payload.isStopped = false;
    }

    public void TakeDamage(int amount)
    {
        OnTakeDamage.Raise();
        _healthScript.TakeDamage(amount);
        if (_healthScript.Health <= 0)
            OnPaylodDied.Raise();
    }

    public void Die()
    {
        Destroy(this.gameObject);
    }

    // Use this for initialization
    private void Start()
    {
        _healthScript = ScriptableObject.CreateInstance<HealthScriptable>();
        _healthScript.Health = this.Health;
        this.transform.position = Path.Steps[0];
        _payload = GetComponent<NavMeshAgent>();
        _payload.destination = Path.Steps[1];
    }

    private int raiseCounter = 0;
    // Update is called once per frame
    private void Update()
    {

        _payload.speed = CurrentSpeed;
        this.Health = _healthScript.Health;
        if (Path == null)
            return;

        if (Mathf.Approximately(this.transform.position.x, Path.Steps[Path.Steps.Count - 1].x) &&
                 Mathf.Approximately(this.transform.position.z, Path.Steps[Path.Steps.Count - 1].z))
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
        _payload.SetDestination(Path.Steps[NextNode]);
    }

    private void Win()
    {
        Debug.Log("You Win!!!!");
        SceneManager.LoadScene("mainmenu");
    }
}
