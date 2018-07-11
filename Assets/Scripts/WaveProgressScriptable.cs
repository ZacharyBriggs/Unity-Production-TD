using UnityEngine;

[CreateAssetMenu(menuName = "Progress")]
public class WaveProgressScriptable : IntVariable
{
    public int MaxEnemies;
    public int Progress;

    public override int Value
    {
        get { return Progress; }
    }

    public override int MaxValue
    {
        get { return MaxEnemies; }
    }

    public virtual void MakeProgress(int amount)
    {
        Progress += amount;
        if (Progress < 100) Debug.Log("Progress was made.");
    }
}