﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PayloadBehaviour : MonoBehaviour, IDamageable
{
    //ToDo: we need to have methods to change the values of the intvariable references
    public HealthScriptable HealthScript;
    [Header("Events")]
    public GameEvent OnPayLoadStopped;
    public GameEvent OnPayloadStart;
    public GameEvent OnTakeDamage;
    public GameEvent OnPaylodDied;
    public bool Stopped;
    public PathSriptable Path;
    [NonSerialized]public int CurrentNode = 0;
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
        HealthScript.TakeDamage(amount);
        if (HealthScript.Health <= 0)
        {
            OnPaylodDied.Raise();
            Die();
        }
    }
    public void Die()
    {
        Destroy(this.gameObject);
        Debug.Log("You are Loser");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("mainmenu");
    }

    void Start()
    {
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
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        SceneManager.LoadScene("mainmenu");
    }
}
