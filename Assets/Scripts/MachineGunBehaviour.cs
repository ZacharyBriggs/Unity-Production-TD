using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class MachineGunBehaviour : MonoBehaviour
{
    public float Cooldown;
    public int Damage;
    public float Range;

    private float Timer;
    private EnemyBehaviour Target;
    private List<EnemyBehaviour> Enemies = new List<EnemyBehaviour>();
    [SerializeField]
    private float Distance;

    // Use this for initialization
    void Start ()
	{
	    Timer = Cooldown;
	    var foundEnemies = FindObjectsOfType<EnemyBehaviour>();
	    foreach (var enemy in foundEnemies)
	    {
	        Enemies.Add(enemy);
	    }
	}
	
	// Update is called once per frame
	void Update ()
	{
	    foreach (var enemy in Enemies)
	    {
	        var distanceFrom = Vector3.Distance(transform.position, enemy.transform.position);
	        if (distanceFrom < Range)
	        {
                if(Target == null)
	                Target = enemy;
                else if (distanceFrom < Vector3.Distance(transform.position, Target.transform.position))
                    Target = enemy;
	        }
	    }
        if (Target != null)
	    {
	        if (Timer <= 0)
	        {
	            if (Vector3.Dot(transform.forward, (Target.transform.position - transform.position).normalized) < 90)
	            {
	                Debug.DrawLine(this.transform.position, Target.transform.position, Color.red, 0.1f);
	                Target.TakeDamage(Damage);
	                Timer = Cooldown;
	            }
	        }
	        Timer -= Time.deltaTime;
	    }
	}
}
