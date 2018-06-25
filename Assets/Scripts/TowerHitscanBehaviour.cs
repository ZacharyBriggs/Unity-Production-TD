using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class TowerHitscanBehaviour : MonoBehaviour
{
    private GameObject Target;

    public float Cooldown;

    private float Timer;

	// Use this for initialization
	void Start ()
	{
	    Timer = Cooldown;
	}
	
	// Update is called once per frame
	void Update ()
	{
        if (Target != null)
	    {
	        EnemyBehaviour enemy = Target.GetComponent<EnemyBehaviour>();
	        if (Timer <= 0)
	        {
	            enemy.HP -= 10;
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
