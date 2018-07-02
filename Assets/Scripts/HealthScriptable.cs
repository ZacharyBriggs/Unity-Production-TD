using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Health")]
public class HealthScriptable : ScriptableObject
{
    public int Health;

    public virtual bool TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Debug.Log("Object is dead.");
            return true;
        }
        return false;
    }
}
