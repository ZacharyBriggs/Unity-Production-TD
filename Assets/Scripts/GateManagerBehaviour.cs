using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManagerBehaviour : MonoBehaviour
{
    private Transform Wall;
    private Transform Wall2;
    private BoxCollider invisWall;
    private BoxCollider invisWall2;
	void Start ()
	{
	    Wall = this.transform.Find("Wall1");
	    invisWall = Wall.GetComponent<BoxCollider>();
	    Wall2 = this.transform.Find("Wall2");
	    invisWall2 = Wall2.GetComponent<BoxCollider>();

	}

	void Update ()
	{
		
	}

    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Payload")
        {
            invisWall.enabled = true;
            invisWall2.enabled = true;
        }
    }
}
