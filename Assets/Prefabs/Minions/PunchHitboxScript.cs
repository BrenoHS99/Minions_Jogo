using UnityEngine;

public class PunchHitboxScript : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyScript enemyConfig;
            enemyConfig = other.gameObject.GetComponent<EnemyScript>();

            enemyConfig.TakeDamage(5f);
        }
    }
}
