using UnityEngine;

public class PunchHitboxScript : MonoBehaviour
{
    public GameObject punchParticles;

    // Configurations
    public float stuartKnockback;
    public float stuartDmg;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);

            GameObject particlesClone = Instantiate(punchParticles, transform.position, transform.rotation);
            Destroy(particlesClone, 1f);

            EnemyScript enemyConfig;
            enemyConfig = other.gameObject.GetComponent<EnemyScript>();

            enemyConfig.TakeDamage(stuartDmg);
            enemyConfig.TakeKnockback(stuartKnockback);
        }
    }
}
