using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    private float smooth = 5.0f;

    private float TiltAngle = 60.0f;

	// Update is called once per frame
	void Update ()
	{
        float TiltAroundZ = Input.GetAxis("Horizontal") * TiltAngle;
	    float TiltAroundX = Input.GetAxis("Vertical") * TiltAngle;
        Quaternion target =Quaternion.Euler(TiltAroundX,0,TiltAroundZ);
        transform.rotation=Quaternion.Slerp(transform.rotation,target,Time.deltaTime * smooth);

    }
}
