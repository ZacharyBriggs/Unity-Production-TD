using System;
using UnityEngine;
using UnityEngine.UI;

public class UIFillAmountBehaviour : MonoBehaviour
{
    public Image _mImage;
    public HealthScriptable Health;


    private void Update()
    {
        _mImage.fillAmount = (float)Health._mValue / Health._mMaxValue;
    }
}