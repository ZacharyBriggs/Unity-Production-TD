using UnityEngine;

[CreateAssetMenu(menuName = "_IntVariable")]
public class HealthScriptable : IntVariable
{
    [SerializeField] private int _mMaxValue = 5;
    [SerializeField] private int _mValue = 1;

    public int Health
    {
        get { return _mValue; }
        set
        {
            _mValue = value;
            if (onValueChanged != null)
                onValueChanged();
        }
    }

    public override int Value
    {
        get { return Health; }
    }

    public override int MaxValue
    {
        get { return _mMaxValue; }
    }

    //ToDo: Move TakeDamage to a MonoBehaviour or interface implementation
    public virtual void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0) Debug.Log("Object is dead.");
    }
}