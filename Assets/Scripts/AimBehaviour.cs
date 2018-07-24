using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class AimBehaviour : MonoBehaviour
{

    public RectTransform m_reticule;
    public float m_smoothSpeed;
    public Transform m_aim;
    public float m_worldOffset = 30;
        

    // Update is called once per frame
    void Update()
    {
        if (m_aim != null)
        {
            Vector3 newpos = Camera.main.WorldToScreenPoint(m_aim.TransformPoint(Vector3.forward * m_worldOffset));
            m_reticule.position = Vector3.Lerp(m_reticule.position, newpos, m_smoothSpeed);

        }
    }
}