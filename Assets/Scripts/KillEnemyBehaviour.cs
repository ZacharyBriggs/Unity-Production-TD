using UnityEngine;

public class KillEnemyBehaviour : MonoBehaviour
{
    public int EnemiesLeft = 20;

    public void KillEnemy()
    {
        EnemiesLeft -= 2;
        Destroy(gameObject);
    }

    // Update is called once per frame
    private void Update()
    {
        KillEnemy();
    }
}