using System;
using UnityEngine;
using UnityEngine.UI;

public class UIFillAmountBehaviour : MonoBehaviour
{
    public Image _mImage;
    public Variable variable;

    private void Start()
    {
        variable.onValueChanged += ChangeFillAmount;
        ChangeFillAmount();
    }

    public void ChangeFillAmount()
    {
        

        var v1 = Convert.ToSingle(variable.Value);
        var v2 = Convert.ToSingle(variable.MaxValue);
        var result = v1 / v2;
        _mImage.fillAmount = result;
    }
}