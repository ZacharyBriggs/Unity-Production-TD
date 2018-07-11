using UnityEngine;
using UnityEngine.UI;

public class UIWaveProgressBarBehaviour : MonoBehaviour
{
    public int EnemiesLeft = 20;
    public int EnemiesTotal = 20;
    public IntVariable Progress;

    public Image WaveProgressUI;
    //Feedback: 1
    //input should only be checked in Update for now
    //in general input should only be checked from one place
    //example: PlayerInput


    //Feedback: 2
    //you would kill an enemy when the space is pressed
    //then define what it means to kill an enemy

    //ToDo: move killing enemy to somewhere related to enemybehaviour
    private void KillEnemy()
    {
        EnemiesLeft -= 2;
        Destroy(gameObject);
    }


    private int CalculateProgress()
    {
        //Feedback: 3
        //use an equation when you are writing code that checks on a series of numbers
        //example: if you write more than 5 lines of code that are if statements stop...
        //enemiesremaining | percent
        //20               | 0
        //0                | 100
        //0/20
        //20/20
        return EnemiesLeft / EnemiesTotal * 100 - 100;
    }

    //Feedback: 4
    //avoid returning the argument to a function. return a localvariable that does SOMETHING to that argument

    // Use this for initialization
    private void Start()
    {
        EnemiesLeft = 20;
    }

    // Update is called once per frame
    private void Update()
    {
        WaveProgressUI.fillAmount = CalculateProgress();
        if (Input.GetKeyDown(KeyCode.Space)) KillEnemy();
    }

    private void ChangeFillAmount()
    {
        WaveProgressUI.fillAmount = Progress.Value / (float)Progress.MaxValue;
    }

    //the way progress is determined is by how many enemies are left
}