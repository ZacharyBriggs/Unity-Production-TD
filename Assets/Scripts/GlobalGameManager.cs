﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class GlobalGameManager : ScriptableObject
{
    public void QuitGame()
    {
        Application.Quit();
    }
}
