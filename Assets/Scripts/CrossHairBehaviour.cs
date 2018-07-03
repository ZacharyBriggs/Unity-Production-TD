using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CrossHairBehaviour : MonoBehaviour
{
    public GameObject gun;
    // Use this for initialization
    void Start()
    {
        gameObject.transform.position = Input.mousePosition;
    }

    // Update is called once per frame
    void Update()
    {
        var crossHairPos = gun.transform.position + (gun.transform.forward * 10);
        Debug.DrawLine(gun.transform.position, crossHairPos);
        transform.position = Camera.main.WorldToScreenPoint(crossHairPos);
        Debug.Log(crossHairPos);
    }

}
