using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIBehaviour : MonoBehaviour
{
    public Image HealthUI;
    public Text HealthText;
    private GameObject Payload;
	// Use this for initialization
	void Start ()
    {
        Payload = GameObject.Find("Payload");
	}
	
	// Update is called once per frame
	void Update ()
    {
        PayloadBehaviour pb = Payload.GetComponent<PayloadBehaviour>();
        //HealthText.text = pb.HP.ToString();
        //float value = pb.HP / 100;
        //HealthUI.fillAmount = value;
	}
}
