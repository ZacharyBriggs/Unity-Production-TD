using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveUIBehaviour : MonoBehaviour
{
    private int WaveNum = 0;
    private Text WaveNumText;
    private void Start()
    {
        WaveNumText = GameObject.Find("WaveNumberText").GetComponent<Text>();
    }
    public void OnWaveCompleted()
    {
        WaveNum++;
        WaveNumText.text = WaveNum.ToString();
    }
}
