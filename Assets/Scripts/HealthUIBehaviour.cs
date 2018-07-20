using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIBehaviour : MonoBehaviour
{
    public Image HealthUI;
    private GameObject Payload;
    void Start()
    {
        Payload = GameObject.Find("Payload");
    }

    void Update()
    {
        PayloadBehaviour pb = Payload.GetComponent<PayloadBehaviour>();
        HealthUI.fillAmount =  (float)pb.HealthScript.Value / pb.HealthScript.MaxValue;
    }
}
