using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowingBehaviour : MonoBehaviour {


    float x_pos=0.0f, y_pos=0.0f, z_pos=0.0f;
   
    Vector3 Playerpos(float x,float, float z)
    {
        Vector3 mPlayerpos;
        mPlayerpos.x = x_pos;
        mPlayerpos.y = y_pos;
        mPlayerpos.z = z_pos;
        return mPlayerpos;

    }
  
	// Use this for initialization
	void Start () {

        

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
