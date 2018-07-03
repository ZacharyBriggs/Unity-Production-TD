using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class MachineGunBehaviour : MonoBehaviour
{
    public float Cooldown;
    public int Damage;
    public float Range;

    private float Timer;
    private GameObject Target;
    private SphereCollider Sphere;

    // Use this for initialization
    void Start ()
	{
	    Timer = Cooldown;
	    Sphere = GetComponent<SphereCollider>();
	    Sphere.radius = Range;
    }
	
	// Update is called once per frame
	void Update ()
	{
        if (Target != null)
	    {
	        EnemyBehaviour enemy = Target.GetComponent<EnemyBehaviour>();
	        if (Timer <= 0)
	        {
                Debug.DrawLine(this.transform.position,Target.transform.position,Color.red,0.1f);
	            if(enemy.GetComponent<EnemyBehaviour>().HealthScriptable.TakeDamage(Damage))
                    enemy.Die();
	            Timer = Cooldown;
	        }

	        Timer -= Time.deltaTime;
	    }
	}

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy" && Target == null)
            Target = collision.gameObject;
    }
}
