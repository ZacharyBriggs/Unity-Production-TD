using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponCoolDownBehaviour : UIWeaponCooldownScriptable
{
    public Image WeaponCoolDownBar;
    public bool IsWeaponHeating;
    private IntVariable mBar;
    public int MaxWeaponHeat;
    public int WeaponHeat;
    public bool WasWeaponShot()
    {
        var Weaponshot = false;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Weaponshot = true;
            return Weaponshot;
        }

        return true;
    }
    public override int Value
    {
        get { return WeaponHeat; }
    }

    public override int MaxValue
    {
        get { return MaxWeaponHeat; }
    }

    public  int StartWeaponHeating()
    {
        if (WasWeaponShot()==true)
        {
            WeaponHeat = +1;
            WeaponCoolDownBar.fillAmount = WeaponHeat;
            if (WeaponHeat >= MaxWeaponHeat)
            {
                IsWeaponHeating = false;
            }
            
        }
        return WeaponHeat;
    }
	// Use this for initialization
	void Start ()
	{
	   
	}
	
	// Update is called once per frame
	void Update () {
	 ChangeFillAmount();
	}

    private void ChangeFillAmount()
    {
        WeaponCoolDownBar.fillAmount = mBar.Value / (float)mBar.MaxValue;
    }
    
}
