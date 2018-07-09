using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarBehaviour :HealthScriptable  
{

    private Slider HealthBar;

    void OnValueChanged(HealthScriptable healthBar)
    {
        if (HealthBar.value > 0)
        {
           HealthBar.value = -10;
        }
    }
	// Use this for initialization
	void Start ()
	{
	    HealthBar.value = Health;

	}
	
	// Update is called once per frame
	void Update () {
		TakeDamage(Health);
        
	}
}
