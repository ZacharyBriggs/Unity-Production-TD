using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehaviour : MonoBehaviour
{    
    private GameObject Target;

    public int HP;
	// Use this for initialization
	void Start ()
	{
	    Target = GameObject.Find("Payload");
	    
	}
	
	// Update is called once per frame
	void Update ()
	{
	    GetComponent<NavMeshAgent>().destination = Target.transform.position;
	    if (HP <= 0)
	    {
            Destroy(this.gameObject);
	    }
    }
}
