using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float Speed = 20;

    private GameObject Player;
	// Use this for initialization
	void Start ()
	{
	    Player = GameObject.Find("Player");
	    Speed *= 500;
	}
	
	// Update is called once per frame
	void Update ()
	{
	    Vector3 direction = Player.transform.position - transform.position;
        direction.Normalize();
	    Rigidbody rb3d = GetComponent<Rigidbody>();
        rb3d.AddForce(direction*Speed*Time.deltaTime);
	}
}
