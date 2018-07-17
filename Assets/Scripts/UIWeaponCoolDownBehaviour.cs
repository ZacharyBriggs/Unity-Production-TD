using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIWeaponCoolDownBehaviour : MonoBehaviour
{
    public Image WeaponCoolDownBar;
    public  float MaxWeaponHeat = 10.0f;
    public float WeaponHeat=0;
    public bool IsWeaponHeating = false;
    public IntVariable weapon_Heat;

    void StartWeaponHeating()
    {
        var timer = Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
          
            WeaponHeat += 1;
            while (WeaponHeat < MaxWeaponHeat)
            {
                WeaponHeat += 1;
                WeaponCoolDownBar.fillAmount = WeaponHeat / MaxWeaponHeat;
            }
        }
    }

    private void ChangeFillAmount()
    {
        WeaponCoolDownBar.fillAmount = weapon_Heat.Value / (float) weapon_Heat.MaxValue;
    }
	// Use this for initialization
	void Start ()
	{
	   
	}
	
	// Update is called once per frame
	void Update () {
	    var WasGunShot = Input.GetKeyDown(KeyCode.Space);
	    if (WasGunShot && IsWeaponHeating == true)
	    {
	        WeaponCoolDownBar.fillAmount = WeaponHeat;
	    }
    }
}
