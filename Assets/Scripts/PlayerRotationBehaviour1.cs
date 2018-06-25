using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotationBehaviour : MonoBehaviour {
    public float Smooth = 5.0f;
    public float TiltAngle = 60.0f;
	// Use this for initialization
	void Start () {
     
        
		
	}
	
	// Update is called once per frame
	void Update () {
	    float tiltAroundZ = Input.GetAxis("Horzontal") * TiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * TiltAngle;
	  //  Quaternion Target = Quaternion.Euler((tiltAroundX, 0, tiltAroundZ));
       // transform.rotation = Quaternion.Slerp((transform.rotation, Target, Time.deltaTime * Smooth));
    }
}
