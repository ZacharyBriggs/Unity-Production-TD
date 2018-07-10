using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public int MaxHealth;
    public int Health;
    public int Damage;
    private GameObject Target;
    protected HealthScriptable HealthScript;

    // Use this for initialization
    void Start()
    {
        Health = MaxHealth;
        HealthScript = ScriptableObject.CreateInstance<HealthScriptable>();
        HealthScript.Health = this.MaxHealth;
        Target = FindObjectOfType<PayloadBehaviour>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = Target.transform.position;
        this.Health = HealthScript.Health;
    }

    public void TakeDamage(int amount)
    {
        HealthScript.TakeDamage(amount);
        if (HealthScript.Health <= 0)
            Destroy(this.gameObject);
    }
    void Attack(GameObject other)
    {
            //Play attack animation
            var target = other.GetComponent<PayloadBehaviour>();
            target.TakeDamage(Damage);
    }

    void OnCollisionEnter(Collision collider)
    {
        if(collider.gameObject.tag == "Payload" || collider.gameObject.tag == "Player")
            Attack(collider.gameObject);
    }
}
