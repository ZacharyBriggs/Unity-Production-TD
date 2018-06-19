using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    public float Speed = 20;
    // Use this for initialization
    void Start()
    {
        Speed *= 500;
    }

    // Update is called once per frame
    void Update()
    {
        Rigidbody rb3d = GetComponent<Rigidbody>();
        if (Input.GetButton("Forward"))
            rb3d.AddForce(Vector3.forward * Speed * Time.deltaTime);
        if (Input.GetButton("Backward"))
            rb3d.AddForce(Vector3.back * Speed * Time.deltaTime);
        if (Input.GetButton("Left"))
            rb3d.AddForce(Vector3.left * Speed * Time.deltaTime);
        if (Input.GetButton("Right"))
            rb3d.AddForce(Vector3.right * Speed * Time.deltaTime);
    }
}
