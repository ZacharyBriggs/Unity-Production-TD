using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Health")]
public class HealthScriptable : ScriptableObject
{
    public int Health;

    public virtual void TakeDamage(int amount)
    {
        Health -= amount;
        if (Health <= 0)
        {
            Debug.Log("Object is dead.");
        }
    }
}
