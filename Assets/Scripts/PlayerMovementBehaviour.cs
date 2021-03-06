﻿using System.Collections;
using System.Collections.Generic;
using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour, IDamageable
{
    public float Speed = 10;
    public float WalkSpeed = 2;
    public float RunSpeed = 4;
    public GameEvent PlayerAiming;
    public GameEvent PlayerStoppedAiming;
    private bool Stunned;
    public Vector3 InputVector;
    private Animator _animator;
    private CharacterController controller;

    public Vector3 camRight;

    public Vector3 camForward;

    void Start()
    {
        _animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }
    //feedback: keep variable assignments and calculations close to each other. this provides clarity in reducing redundant assignments and errors
    // Update is called once per frame
    public static bool TOGGLEMOVE;
    void Update()
    {
        //if toggle move is true the player is aiming
        GetWalk();
        if (TOGGLEMOVE)
        {
            PlayerAiming.Raise();
            OldMove();
        }
        else
        {
            PlayerStoppedAiming.Raise();
            Move();
        }

        SetAnimator();

    }

    void GetWalk()
    {
        bool walking = PlayerInput.InputVector.magnitude > 0;
        if (walking)
            Speed = PlayerInput.Sprint ? RunSpeed : WalkSpeed;
    }
    private Vector3 moveVector;

    void OldMove()
    {
        camRight = Camera.main.transform.right;
        camForward = Camera.main.transform.forward;
        camForward *= PlayerInput.InputVector.z;
        camRight *= PlayerInput.InputVector.x;

        moveVector = (camForward + camRight);
        var right = new Vector3(camForward.z, 0, -camForward.x);

        transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * 99 * Time.deltaTime);
        controller.SimpleMove(moveVector.normalized * Speed);

    }

    void SetAnimator()
    {
        _animator.SetFloat("Speed", controller.velocity.magnitude);
    }

    void Move()
    {
        if (controller.isGrounded && !Stunned)
        {
            var h = PlayerInput.InputVector.normalized.x;
            var v = PlayerInput.InputVector.normalized.z;
            var forward = Camera.main.transform.TransformDirection(Vector3.forward);
            forward.y = 0;
            forward = forward.normalized;
            //such copy paste but it works
            var right = new Vector3(forward.z, 0, -forward.x);
            var targetDir = h * right + v * forward;
            if (targetDir.magnitude > 0)
                transform.rotation = Quaternion.LookRotation(targetDir);

            moveVector = targetDir;
        }

        controller.SimpleMove(moveVector * Speed);
    }

    public void TakeDamage(int amount)
    {
        Stunned = true;
        _animator.SetBool("IsStunned",true);
    }

    void StopStun()
    {
        Stunned = false;
        _animator.SetBool("IsStunned", false);
    }
}
