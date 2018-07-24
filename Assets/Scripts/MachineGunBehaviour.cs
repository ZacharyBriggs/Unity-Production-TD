using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunBehaviour : MonoBehaviour
{
    public float FireRate;
    public int Damage;
    public float Range;
    protected EnemyBehaviour Target;
    protected float Timer;
    private LineRenderer line;

    void Start()
    {
        Timer = FireRate;
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
            Timer = FireRate;
        }
    }

    public GameEvent OnShootEvent;

}
