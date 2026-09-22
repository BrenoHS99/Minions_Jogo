using UnityEngine;

public class PunchHitboxScript : MonoBehaviour
{
    public GameObject punchParticles;

    // Configurations
    public float stuartKnockback;
    public float stuartDmg;

    // SFXManager

    private GameObject SFXmanager;

    private GameObject hitSfx;
    private AudioSource hitAudio;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            this.gameObject.SetActive(false);

            SFXmanager = GameObject.FindWithTag("SFXManager");
            hitSfx = SFXmanager.transform.Find("Hit").gameObject;
            hitAudio = hitSfx.GetComponent<AudioSource>();

            hitAudio.PlayOneShot(hitAudio.clip);

            GameObject particlesClone = Instantiate(punchParticles, transform.position, transform.rotation);
            Destroy(particlesClone, 1f);

            EnemyScript enemyConfig;
            enemyConfig = other.gameObject.GetComponent<EnemyScript>();

            enemyConfig.TakeDamage(stuartDmg);
            enemyConfig.TakeKnockback(stuartKnockback);
        }
    }
}
