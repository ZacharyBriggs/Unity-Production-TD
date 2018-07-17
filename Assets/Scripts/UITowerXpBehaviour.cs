using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;
using UnityEngine.UI;

public class UITowerXpBehaviour : UIXPBarScriptable
{
    public IntVariable XPBar;
    public Image mXpBar;


    public void FillAmount()
    {
        mXpBar.fillAmount = Total_Xp / Max_Xp;
    }
 
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
       FillAmount();
	}
}
