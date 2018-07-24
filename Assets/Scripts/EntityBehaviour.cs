using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBehaviour : MonoBehaviour, IDamageable {

    public HealthScriptable Health;
    IDamageable damageable;
    public void Start()
    {
        damageable = this;    
    }

    public void TakeDamage(int amount)
    {
        Health.TakeDamage(amount);        
    }
}
