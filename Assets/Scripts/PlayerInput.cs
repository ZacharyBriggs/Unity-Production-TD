﻿using UnityEngine;

public static class PlayerInput
{
    public static Vector3 InputVector
    {
        get
        {
            var h = Input.GetAxis("Horizontal");
            var v = Input.GetAxis("Vertical");
            return new Vector3(h, 0, v);
        }
    }

    public static bool Sprint
    {
        get
        {
            return Input.GetButton("Sprint");
        }
    }

}