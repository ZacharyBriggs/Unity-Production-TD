using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "XPBAR")]
public class UIXPBarScriptable : IntVariable
{
    public int Total_Xp = 0;

    public int Max_Xp = 100;
    // Use this for initialization


    public override int Value
    {
        get { return Total_Xp; }
    }

    public override int MaxValue
    {
        get { return Max_Xp; }
    }

    public virtual void Gain_Xp(int amount)
    {
        Total_Xp += amount;
        if (Total_Xp < 100) Debug.Log("Gained XP");
    }
}
