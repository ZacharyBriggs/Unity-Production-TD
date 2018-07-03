﻿using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Constraints;
using UnityEditor;
using UnityEngine;

public class TeslaCoilBehaviour : MonoBehaviour
{
    public float Cooldown;
    public int Damage;
    public float Range;

    private List<BoltScriptable> Bolts = new List<BoltScriptable>();
    private float Timer;
    private List<EnemyBehaviour> Enemies = new List<EnemyBehaviour>();

    void Start ()
    {
        Timer = Cooldown;
	    var foundEnemies = FindObjectsOfType<EnemyBehaviour>();
	    foreach (var enemy in foundEnemies)
	    {
	        Enemies.Add(enemy);
	    }
    }
	
	void Update ()
	{
	    foreach (var bolt in Bolts)
        { 
	        if (bolt.Target == null)
	            Bolts.Remove(bolt);
	    }
        foreach (var enemy in Enemies)
	    {
	        if (enemy == null)
	        {
	            Enemies.Remove(enemy);
	            break;
	        }

	        var distanceFrom = Vector3.Distance(transform.position, enemy.transform.position);
	        if (distanceFrom < Range && Timer <= 0)
	        {
	            if (Vector3.Dot(transform.forward, (enemy.transform.position - transform.position).normalized) < 90)
	            {
	                bool enemyNotTargeted = true;
	                foreach (var bolt in Bolts)
	                {
	                    if (bolt.Target == enemy)
	                        enemyNotTargeted = false;
	                }

	                if (enemyNotTargeted)
	                {
	                    var newBolt = ScriptableObject.CreateInstance<BoltScriptable>();
                        newBolt.Init(enemy,this.transform.position);
	                    Bolts.Add(newBolt);
	                }
	            }
	        }
	    }

	    if (Timer <= 0)
	    {
	        foreach (var bolt in Bolts)
	        {
	            bolt.Attack(Damage);
	        }

	        Timer = Cooldown;
	    }

	    Timer -= Time.deltaTime;
	}
}
