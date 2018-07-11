﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingBehaviour : MachineGunBehaviour
{
    public GameObject fpscam;
    public GameObject freelookcam;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        fpscam.SetActive(Input.GetButton("Fire2"));
        freelookcam.SetActive(!Input.GetButton("Fire2"));
        freelookcam.GetComponent<Cinemachine.CinemachineVirtualCameraBase>().enabled = !Input.GetButton("Fire2");
        PlayerMovementBehaviour.TOGGLEMOVE = Input.GetButton("Fire2");
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit = new RaycastHit();
            var camforwardcast = Camera.main.transform.forward * 1000;
            if (Physics.Raycast(this.transform.position, camforwardcast, out hit))
            {
                Debug.Log("Hit " + hit.collider.gameObject.tag);
                Debug.DrawRay(this.transform.position, camforwardcast, Color.yellow, 1);
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
