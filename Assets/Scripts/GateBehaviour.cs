using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateBehaviour : MonoBehaviour {

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "PLayer")
        {
        }
    }
}
