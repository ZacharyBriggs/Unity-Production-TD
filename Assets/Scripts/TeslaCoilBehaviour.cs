using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeslaCoilBehaviour : MonoBehaviour
{
    public float Cooldown;
    public int Damage;
    public float Range;

    private SphereCollider Sphere;
    private float Timer;
    private GameObject Target;

    void Start ()
	{
	    Timer = Cooldown;
	    Sphere = GetComponent<SphereCollider>();
	    Sphere.radius = Range;
    }
	
	void Update ()
	{
	    Timer -= Time.deltaTime;
	}

    void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.tag == "Enemy")
            if (Timer <= 0)
            {
                Debug.DrawLine(this.transform.position, collision.gameObject.transform.position, Color.yellow,0.1f);
                EnemyBehaviour enemy = collision.GetComponent<EnemyBehaviour>();
                if (enemy.HealthScriptable.TakeDamage(Damage))
                    enemy.Die();
                Timer = Cooldown;
            }
    }
}
