using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFieldofViewbehaviour : MonoBehaviour {
    //This is the field of view that the camera has.
    float m_fieldofView;

    // Use this for initialization
    void Start()
    {
        m_fieldofView = 60.0f;
    }

    // Update is called once per frame
    //Update the camera's field of view to be the varaible returning.
    void Update()
    {
        Camera.main.fieldOfView = m_fieldofView;
    }
    private void OnGUI()
    {
        float max, min;
        max = 150.0f;
        min = 20.0f;
        m_fieldofView = GUI.HorizontalSlider(new Rect(20, 20, 100, 40),m_fieldofView,min,max );
        m_fieldofView = GUI.VerticalSlider(new Rect(20, 20, 100, 40),m_fieldofView,min,max);
    }

    }
