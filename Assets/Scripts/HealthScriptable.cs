using UnityEngine;

[CreateAssetMenu(menuName = "_IntVariable")]
public class HealthScriptable : IntVariable
{
    [SerializeField] public int _mMaxValue;
    [SerializeField] public int _mValue;
    
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
 
    //ToDo: Move TakeDamage to a MonoBehaviour or interface implementation
    public virtual void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
        {

        }
    }

    public virtual void Recover(int amount)
    {
        Health += amount;
        if (Health < _mMaxValue)
        {
            Debug.Log("Healing");
        }
    }
}