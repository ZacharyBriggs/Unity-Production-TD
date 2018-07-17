using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLookSensitivityBehaviour : MonoBehaviour
{
    public Vector2 SmoothMouse;
    public Vector2 Sensitivity = new Vector2(2, 2);
    public Vector2 Smoothing = new Vector2(3, 3);

    // Use this for initialization
    void Start ()
    {
     
    }
	
	// Update is called once per frame
	void Update ()
	{
	    var MouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("MouseY"));
        MouseDelta=Vector2.Scale(MouseDelta,new Vector2(Sensitivity.x * Smoothing.x,Sensitivity.y *Smoothing.y));
	}
}
