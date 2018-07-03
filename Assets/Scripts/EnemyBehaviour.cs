using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{
    public int Health;
    public int Damage;
    private GameObject Target;
    public HealthScriptable HealthScriptable;

    // Use this for initialization
    void Start()
    {
        HealthScriptable.Health = this.Health;
        Target = FindObjectOfType<PayloadBehaviour>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<NavMeshAgent>().destination = Target.transform.position;
        this.Health = HealthScriptable.Health;
    }

    void Attack(GameObject other)
    {
        if (other.tag == "Payload")
        {
            //Play attack animation
            PayloadBehaviour target = other.GetComponent<PayloadBehaviour>();
            if (target.HealthScriptable.TakeDamage(Damage))
                other.GetComponent<PayloadBehaviour>().Die();
        }

    }
    public void Die()
    {
        //isdead = true;
        Destroy(this.gameObject);
    }

    void OnCollisionEnter(Collision collider)
    {
        if(collider.gameObject.tag == "Payload" || collider.gameObject.tag == "Player")
            Attack(collider.gameObject);
    }
}
