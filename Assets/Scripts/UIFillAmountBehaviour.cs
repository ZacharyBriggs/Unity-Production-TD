using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFillAmountBehaviour : MonoBehaviour
{
    public Image _mImage;
    public Variable variable;

    void Start()
    {
        ChangeFillAmount();
        variable.onValueChanged += ChangeFillAmount;
    }

    public void ChangeFillAmount()
    {

        float result = (float)variable.Value / (float)variable.MaxValue;
        _mImage.fillAmount = result;
    }

}
