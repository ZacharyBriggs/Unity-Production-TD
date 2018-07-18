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
    private LineRenderer line;

    void Start()
    {
        Timer = Cooldown;
        line = GetComponent<LineRenderer>();
        line.alignment = LineAlignment.Local;
    }

    void Update()
    {
        Timer -= Time.deltaTime;
    }

    protected void Shoot()
    {
        if (Target != null)
        {
           
            Target.TakeDamage(Damage);
            Timer = Cooldown;
        }
    }

    public GameEvent OnShootEvent;

}
