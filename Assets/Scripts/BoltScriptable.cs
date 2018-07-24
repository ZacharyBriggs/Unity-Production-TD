using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoltScriptable : ScriptableObject
{
    public Vector3 Position;
    public EnemyBehaviour Target;

    public void Init(EnemyBehaviour target, Vector3 pos)
    {
        Target = target;
        Position = pos;
    }

    public void Attack(int damage)
    {
        Target.TakeDamage(damage);
        Debug.DrawLine(Position, Target.transform.position, Color.yellow,0.1f);
    }
}
