using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingBehaviour : MachineGunBehaviour
{
    public GameObject Fpscam;
    public GameObject Freelookcam;

    void Start()
    {
        //    Cursor.visible = true;
        //    Cursor.lockState = CursorLockMode.Locked;
    }

    public GameEvent OnAimStart;
    public GameEvent OnAimEnd;
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            OnAimStart.Raise();
        }

        if (Input.GetButtonUp("Fire2"))
        {
            OnAimEnd.Raise();
        }

        Fpscam.SetActive(Input.GetButton("Fire2"));
        Freelookcam.SetActive(!Input.GetButton("Fire2"));
        var vcam = Freelookcam.GetComponent<Cinemachine.CinemachineVirtualCameraBase>();
        if (vcam != null)
            vcam.enabled = !Input.GetButton("Fire2");
        PlayerMovementBehaviour.TOGGLEMOVE = Input.GetButton("Fire2");
        if (Input.GetButtonDown("Fire1"))
        {

            base.Shoot();
        }
    }
}


