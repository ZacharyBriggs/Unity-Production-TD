using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Cooldown")]
public class UIWeaponCooldownScriptable : IntVariable
{
    
    public int MaxTemp;
    public int Temp;

    public override int Value
    {
        get { return Temp; }
    }

    public override int MaxValue
    {
        get { return MaxTemp; }
    }

    public virtual void HeatWeapon(int amount)
    {
        Temp += amount;
        if (Temp < 100) Debug.Log("Weapon Cool.");
        if (Temp == 100) Debug.Log("Weapon OVer Heated.");
      
    }

  
}
