using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class MachineGunTurretBehaviour : MachineGunBehaviour
{
    
    private List<EnemyBehaviour> Enemies = new List<EnemyBehaviour>();

    void Start ()
	{
	    var foundEnemies = FindObjectsOfType<EnemyBehaviour>();
	    foreach (var enemy in foundEnemies)
	    {
	        Enemies.Add(enemy);
	    }
	}
	
    void Update()
    {
        foreach (var enemy in Enemies)
        {
            var distanceFrom = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceFrom < Range)
            {
                if (Target == null)
                    Target = enemy;
                else if (distanceFrom < Vector3.Distance(transform.position, Target.transform.position))
                    Target = enemy;
            }
        }

        if (Timer <= 0 && Target != null)
        {
            if (Vector3.Dot(transform.forward, Target.transform.position - transform.position) > 0)
            {
                Shoot();
            }
        }
        
    }
}
