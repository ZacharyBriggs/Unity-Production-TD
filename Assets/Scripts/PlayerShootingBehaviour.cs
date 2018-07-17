using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingBehaviour : MachineGunBehaviour
{
    public GameObject Fpscam;
    public GameObject Freelookcam;
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {

        Fpscam.SetActive(Input.GetButton("Fire2"));
        Freelookcam.SetActive(!Input.GetButton("Fire2"));
        Freelookcam.GetComponent<Cinemachine.CinemachineVirtualCameraBase>().enabled = !Input.GetButton("Fire2");
        PlayerMovementBehaviour.TOGGLEMOVE = Input.GetButton("Fire2");
        if (Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit = new RaycastHit();
            var camforwardcast = Camera.main.transform.forward * 1000;
            if (Physics.Raycast(this.transform.position, camforwardcast, out hit))
            {
                Debug.Log("Hit " + hit.collider.gameObject.tag);
                Debug.DrawRay(this.transform.position, camforwardcast, Color.yellow, 1);
                if (hit.collider.gameObject.CompareTag("Enemy"))
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
