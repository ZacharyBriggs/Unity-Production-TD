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
    public GameEvent OnCooldown;
    public Image CooldownFill;
    private Animator animator;
    public GameObject Prefab;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        animator = GetComponentInParent<Animator>();
    }


    void Update()
    {
        CooldownFill.fillAmount = HeatMeter / MaxHeat;
        HeatMeter -= Time.deltaTime*5;
        Fpscam.SetActive(Input.GetButton("Fire2"));
        Freelookcam.SetActive(!Input.GetButton("Fire2"));
        Freelookcam.GetComponent<Cinemachine.CinemachineVirtualCameraBase>().enabled = !Input.GetButton("Fire2");
        PlayerMovementBehaviour.TOGGLEMOVE = Input.GetButton("Fire2");
        if (Input.GetButtonDown("Fire1") && !CoolingDown)
        {
            OnShootEvent.Raise();
            animator.Play("RapidShot");
            HeatMeter += HeatRate;
            RaycastHit hit = new RaycastHit();
            var camforwardcast = Camera.main.transform.forward * 1000;
            camforwardcast.x += 125;
            camforwardcast.y += 25;
            var linerender = GetComponent<LineRenderer>();
            linerender.SetPosition(0,this.transform.position);
            linerender.SetPosition(1,camforwardcast);
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

            linerender.positionCount = 0;
        }

        if (HeatMeter >= MaxHeat || Input.GetButtonDown("Reload"))
        {
            CoolingDown = true;
            animator.SetBool("IsCooldown", true);
            OnCooldown.Raise();
        }
        if(CoolingDown)
        {
            HeatMeter -= 175*Time.deltaTime;
            if (HeatMeter <= 0)
            {
                CoolingDown = false;
                animator.SetBool("IsCooldown", false);
            }
        }
    }

}
