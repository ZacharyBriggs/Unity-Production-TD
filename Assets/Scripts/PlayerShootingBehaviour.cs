using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShootingBehaviour : MachineGunBehaviour
{
    public GameObject Fpscam;
    public GameObject Freelookcam;
    public float HeatRate = 10;
    private float HeatMeter = 0;
    public float MaxHeat = 100;
    private bool CoolingDown = false;
    public int CooldownRate = 1000;
    public GameEvent OnCooldown;
    public Image CooldownFill;
    private Animator animator;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponentInParent<Animator>();
    }


    void Update()
    {
        CooldownFill.fillAmount = HeatMeter / MaxHeat;
        Fpscam.SetActive(Input.GetButton("Fire2"));
        Freelookcam.SetActive(!Input.GetButton("Fire2"));
        Freelookcam.GetComponent<Cinemachine.CinemachineVirtualCameraBase>().enabled = !Input.GetButton("Fire2");
        PlayerMovementBehaviour.TOGGLEMOVE = Input.GetButton("Fire2");
        if (Input.GetButtonDown("Fire1") && !CoolingDown)
        {
            OnShootEvent.Raise();
            HeatMeter += HeatRate;
            RaycastHit hit = new RaycastHit();
            var camforwardcast = Camera.main.transform.forward * 1000;
            //todo:: we could set the linerenderer to exactly where it goes if we make it here
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
        if (HeatMeter >= MaxHeat || Input.GetButtonDown("Reload"))
        {
            CoolingDown = true;
            animator.SetBool("IsCooldown", true);
            OnCooldown.Raise();
        }
        if(CoolingDown)
        {
            HeatMeter -= CooldownRate*Time.deltaTime;
            if (HeatMeter <= 0)
            {
                CoolingDown = false;
                animator.SetBool("IsCooldown", false);
            }
        }
    }

}
