using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIFillAmountBehaviour : MonoBehaviour
{
    public Image _mImage;
    public IntVariable _IntVariable;

    void Start()
    {
        ChangeFillAmount();
        _IntVariable.onValueChanged += ChangeFillAmount;
    }

    public void ChangeFillAmount()
    {
        _mImage.fillAmount = _IntVariable.Value / (float)_IntVariable.MaxValue;
    }

}
