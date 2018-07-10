using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManagerBehaviour : MonoBehaviour
{
    private Transform Wall;
    private BoxCollider invisWall;
	void Start ()
	{
	    Wall = this.transform.Find("Gate1Wall");
	    invisWall = Wall.GetComponent<BoxCollider>();
	}

	void Update ()
	{
		
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Payload")
        {
            invisWall.enabled = true;
        }
    }
}
