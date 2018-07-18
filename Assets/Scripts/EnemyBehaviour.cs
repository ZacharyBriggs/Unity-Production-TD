using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public int Health;
    [NonSerialized]public int MaxHealth;
    public int Damage = 10;
    private GameObject _target;
    private HealthScriptable _healthScript;
    public GameEvent OnEnemyDamageTaken;
    public GameEvent OnEnemyDied;

    // Use this for initialization
    private void Start()
    {
        _healthScript = ScriptableObject.CreateInstance<HealthScriptable>();
        _healthScript.Health = this.Health;
        MaxHealth = _healthScript.Health;
        _target = FindObjectOfType<PayloadBehaviour>().gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        GetComponent<NavMeshAgent>().destination = _target.transform.position;
        this.Health = _healthScript.Health;
    }

    public void TakeDamage(int amount)
    {
        _healthScript.TakeDamage(amount);
        OnEnemyDamageTaken.Raise();
        if (_healthScript.Health <= 0)
        {
            OnEnemyDied.Raise();
        }
            
    }

    private void Attack(GameObject other)
    {
            //Play attack animation
            var target = other.GetComponent<PayloadBehaviour>();
            target.TakeDamage(Damage);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Payload") || collision.gameObject.CompareTag("Player"))
            Attack(collision.gameObject);
    }
}
