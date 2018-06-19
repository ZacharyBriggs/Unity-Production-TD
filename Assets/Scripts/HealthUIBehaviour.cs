using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIBehaviour : MonoBehaviour
{
    public Image HealthUI;
    public Text HealthText;
    private GameObject Player;
	// Use this for initialization
	void Start ()
    {
        Player = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerBehaviour pb = Player.GetComponent<PlayerBehaviour>();
        HealthText.text = pb.HP.ToString();
        float value = pb.HP / 100;
        HealthUI.fillAmount = value;
	}
}
