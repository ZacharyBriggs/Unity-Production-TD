using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGunBehaviour : MonoBehaviour
{
    public float FireRate;
    public int Damage;
    public float Range;
    [SerializeField]
    protected EnemyBehaviour Target;
    [SerializeField]
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
            if (Target.Health > 0)
            {
                Target.TakeDamage(Damage);
                Timer = FireRate;
            }
        }
    }

    public GameEvent OnShootEvent;

}
