using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using NUnit.Framework.Constraints;
using UnityEditor;
#endif
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
            {
                Bolts.Remove(bolt);
            }

            var distanceFrom = Vector3.Distance(bolt.Target.transform.position, this.transform.position);
            var test =
                Vector3.Dot(transform.forward, (bolt.Target.transform.position - transform.position));
            if (distanceFrom > Range || Vector3.Dot(transform.forward, (bolt.Target.transform.position - transform.position)) < 0)
            {
                Bolts.Remove(bolt);
            }

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
	            if (Vector3.Dot(transform.forward, (enemy.transform.position - transform.position)) > 0)
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
