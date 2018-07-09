using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingBehaviour : MachineGunBehaviour
{

	void Start ()
	{
		
	}
	
	void Update ()
	{
	    if (Input.GetButtonDown("Fire1"))
	    {
	        RaycastHit hit = new RaycastHit();
            if (Physics.Raycast(this.transform.position, this.transform.forward*1000,out hit))
	        {
                Debug.Log("Hit " + hit.collider.gameObject.tag);
	            Debug.DrawRay(this.transform.position, this.transform.forward*1000, Color.yellow,1);
                if (hit.collider.gameObject.tag == "Enemy")
	            {
                    Target = hit.collider.gameObject.GetComponent<EnemyBehaviour>();
	                Shoot();
	            }
	        }
	        else
	        {
	            Debug.Log("Did not hit.");
	        }
	    }
	}
}
