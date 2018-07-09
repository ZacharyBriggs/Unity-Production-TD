using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunBehaviour : MonoBehaviour
{
    public float Cooldown;
    public int Damage;
    public float Range;
    protected EnemyBehaviour Target;
    protected float Timer;

    void Start()
    {
        Timer = Cooldown;
    }

    void Update()
    {
        Timer -= Time.deltaTime;
    }

    protected void Shoot()
    {
        if (Target != null)
        {
            Debug.DrawLine(this.transform.position, Target.transform.position, Color.red, 0.1f);
            Target.TakeDamage(Damage);
            Timer = Cooldown;
        }
    }

}
