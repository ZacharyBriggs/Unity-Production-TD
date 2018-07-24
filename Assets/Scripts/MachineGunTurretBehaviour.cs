using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Networking;

public class MachineGunTurretBehaviour : MachineGunBehaviour
{
    
    public List<EnemyBehaviour> Enemies = new List<EnemyBehaviour>();

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
        Timer -= Time.deltaTime;
        Enemies = new List<EnemyBehaviour>();
        var foundEnemies = FindObjectsOfType<EnemyBehaviour>();
        foreach (var enemy in foundEnemies)
        {
            Enemies.Add(enemy);
        }
        foreach (var enemy in Enemies)
        {
            if (enemy == null)
            {
                Enemies.Remove(enemy);
                return;
            }
            var distanceFrom = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceFrom < Range)
            {
                if (Target == null)
                    Target = enemy;
            }
        }

        if (Timer <= 0 && Target != null)
        {
            float dot = Vector3.Dot(transform.forward, Target.transform.position - transform.position);
            Debug.DrawLine(transform.position, Target.transform.position);
            if (Vector3.Dot(transform.forward, Target.transform.position - transform.position) > 0)
            {
                Shoot();
            }
        }
        
    }
}
