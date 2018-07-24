using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class WaveUIBehaviour : MonoBehaviour
{
    public List<WaveScriptable> WaveList;
    private int DeadEnemies = 0;
    private int WaveNum = 0;
    private Image WaveFill;
    private Text WaveNumText;
    private void Start()
    {
        WaveFill = GameObject.Find("WaveProgressFill").GetComponent<Image>();
        WaveNumText = GameObject.Find("WaveNumberText").GetComponent<Text>();
        WaveNumText.text = (WaveNum + 1).ToString();
    }
    public void OnWaveCompleted()
    {
        WaveFill.fillAmount = 0;
        WaveNum++;
        WaveNumText.text = (WaveNum + 1).ToString();
    }

    public void OnEnemyDied()
    {
        DeadEnemies++;
        WaveFill.fillAmount = (float) DeadEnemies / WaveList[WaveNum].MaxEnemies;
    }
}
