using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    public float Speed = 10;
    public Vector3 InputVector;
    private CharacterController controller;

    public Vector3 camRight;

    public Vector3 camForward;
    // Use this for initialization
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        camRight = Camera.main.transform.right;
        camForward = Camera.main.transform.forward;
        var h = Input.GetAxis("Horizontal");
        var v = Input.GetAxis("Vertical");
        InputVector = new Vector3(h,0,v);
        camForward *= InputVector.z;
        camRight *= InputVector.x;
        Vector3 moveVector = (camForward + camRight);
        controller.SimpleMove(moveVector.normalized*Speed);
    }
}
