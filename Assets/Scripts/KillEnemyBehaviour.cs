using UnityEngine;

public class KillEnemyBehaviour : MonoBehaviour
{
    private void KillEnemy()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            if (gameObject.name == "Enemy")
                DestroyObject(gameObject);
    }
    
    // Update is called once per frame
    private void Update()
    {
        KillEnemy();
    }
}