using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    [NonSerialized]public int MaxHealth;
    [NonSerialized]public int Health;
    public int Damage;
    private GameObject _target;
    private HealthScriptable _healthScript;

    // Use this for initialization
    private void Start()
    {
        _healthScript = ScriptableObject.CreateInstance<HealthScriptable>();
        MaxHealth = _healthScript.Health;
        _target = FindObjectOfType<PayloadBehaviour>().gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        GetComponent<NavMeshAgent>().destination = _target.transform.position;
        this.Health = _healthScript.Health;
    }
    public UnityEngine.Events.UnityEvent OnEnemyDied;
    public void TakeDamage(int amount)
    {
        _healthScript.TakeDamage(amount);
        if (_healthScript.Health <= 0)
        {
            OnEnemyDied.Invoke();
            Destroy(this.gameObject);
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
