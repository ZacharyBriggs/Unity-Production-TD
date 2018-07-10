using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBarBehaviour : MonoBehaviour
{
    private EnemyBehaviour Enemy;
    private SpriteRenderer HealthBarImage;
	// Use this for initialization
	void Start ()
	{
	    Enemy = GetComponent<EnemyBehaviour>();
	    HealthBarImage = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}
}
