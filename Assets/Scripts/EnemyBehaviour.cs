﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour, IDamageable
{
    public int Health;
    [NonSerialized]public int MaxHealth;
    public int Damage = 10;
    private GameObject _target;
    private HealthScriptable _healthScript;
    private bool IsAttacking;
    public GameEvent OnEnemyDamageTaken;
    public GameEvent OnEnemyAttacked;
    private GameEvent OnEnemyDied;
    private Animator animator;
    private NavMeshAgent _navAgent;
    private IDamageable attackTarget;

    // Use this for initialization
    private void Start()
    {
        animator = GetComponent<Animator>();
        OnEnemyDied = ScriptableObject.CreateInstance<GameEvent>();
        _healthScript = ScriptableObject.CreateInstance<HealthScriptable>();
        _healthScript.Health = this.Health;
        MaxHealth = _healthScript.Health;
        _target = FindObjectOfType<PayloadBehaviour>().gameObject;
        _navAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    private void Update()
    {
        _navAgent.destination = _target.transform.position;
        animator.SetFloat("Speed",_navAgent.velocity.magnitude);
        this.Health = _healthScript.Health;
    }

    public void TakeDamage(int amount)
    {
        _healthScript.TakeDamage(amount);
        OnEnemyDamageTaken.Raise();
        if (_healthScript.Health <= 0)
        {
            OnEnemyDied.Raise();
            animator.SetBool("IsDead",true);
        }
            
    }
    private void Attack(IDamageable damageable)
    {
        animator.SetBool("IsAttacking", true);
        attackTarget = damageable;
    }

    void StopAttacking()
    {
        attackTarget.TakeDamage(Damage);
        animator.SetBool("IsAttacking",false);
    }

    void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Payload") || other.gameObject.CompareTag("Player"))
            Attack(other.gameObject.GetComponent<IDamageable>());
    }
}
