using UnityEngine;

[CreateAssetMenu(menuName = "Progress")]
public class UIWaveProgressScriptable : IntVariable
{
    public int MaxEnemies;
    public int Progress
    {
        get { return _value; }
        set
        {
            _value = value;
        }
    }
    public virtual void MakeProgress(int amount)
    {
        Progress += amount;
        if (Progress < 100) Debug.Log("Progress was made.");
    }
}