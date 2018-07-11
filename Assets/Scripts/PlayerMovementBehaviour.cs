using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    public float Speed = 10;
    public float WalkSpeed = 2;
    public float RunSpeed = 4;
    public Vector3 InputVector;
    private Animator animation;
    private CharacterController controller;

    public Vector3 camRight;

    public Vector3 camForward;
    // Use this for initialization
    void Start()
    {
        animation = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    // Update is called once per frame
    void Update()
    {
        camRight = Camera.main.transform.right;
        camForward = Camera.main.transform.forward;
        bool walking = PlayerInput.InputVector.magnitude > 0;
        if (walking)
            Speed = PlayerInput.Sprint() ? RunSpeed : WalkSpeed;
        animation.SetBool("IsWalking", walking);
        camForward *= PlayerInput.InputVector.z;
        camRight *= PlayerInput.InputVector.x;
        Vector3 moveVector = (camForward + camRight);
        controller.SimpleMove(moveVector.normalized * Speed);
    }
}
