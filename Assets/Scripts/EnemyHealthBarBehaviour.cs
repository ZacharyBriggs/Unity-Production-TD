using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBarBehaviour : MonoBehaviour
{
    private Image HealthBarImage;
    private EnemyBehaviour Enemy;
	// Use this for initialization
	void Start ()
	{
	    Enemy = GetComponent<EnemyBehaviour>();
	    var canvas = this.transform.Find("Canvas");
	    HealthBarImage = canvas.transform.Find("FillBar").GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	    HealthBarImage.fillAmount = (float)Enemy.Health / Enemy.MaxHealth;
	}
}
