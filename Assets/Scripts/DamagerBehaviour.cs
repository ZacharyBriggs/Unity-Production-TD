using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagerBehaviour : MonoBehaviour
{
    public int Damage;

    private Rigidbody rb3d;
	// Use this for initialization
	void Start ()
	{
	    rb3d = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    void OnCollisionEnter(Collision collision)
    {
        EnemyBehaviour enemy = collision.gameObject.GetComponent<EnemyBehaviour>();
        enemy.HP -= Damage;
    }
}
