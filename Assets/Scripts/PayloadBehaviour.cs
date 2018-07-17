using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PayloadBehaviour : MonoBehaviour
{
//ToDo: we need to have methods to change the values of the intvariable references    
    private HealthScriptable HealthScript;
    [Header("Events")]
    public GameEvent OnPayLoadStopped;
    public GameEvent OnPayloadStart;
    public GameEvent OnTakeDamage;
    public GameEvent OnPaylodDied;
    public bool Stopped;
    public PathSriptable Path;
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
        HealthScript.Health -= amount;
        if (HealthScript.Health <= 0)
            OnPaylodDied.Raise();
    }
    public void Die()
    {
        Destroy(this.gameObject);
    }

    void Start()
    {
        HealthScript = ScriptableObject.CreateInstance<HealthScriptable>();
        this.transform.position = Path.Steps[0];
        _payload = GetComponent<NavMeshAgent>();
        _payload.destination = Path.Steps[1];
    }

    void Update()
    {
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

    void ChangeDestination()
    {
        CurrentNode = NextNode;
        NextNode += 1;
        _payload.SetDestination(Path.Steps[NextNode]);
    }
    void Win()
    {
        Debug.Log("You Win!!!!");
        SceneManager.LoadScene("mainmenu");
    }
}
