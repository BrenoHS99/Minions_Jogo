using UnityEngine;

public class HeatBulletScript : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletKnockback;
    public float bulletDmg;

    public GameObject bulletExplosionPart;

    // SFXManager

    private GameObject SFXmanager;

    private GameObject shootHitSfx;
    private AudioSource shootHitAudio;

    void Start()
    {
        Destroy(this.gameObject, 3f);

        SFXmanager = GameObject.FindWithTag("SFXManager");

        shootHitSfx = SFXmanager.transform.Find("ShootHit").gameObject;

        shootHitAudio = shootHitSfx.GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            shootHitAudio.PlayOneShot(shootHitAudio.clip);

            EnemyScript enemyScript = other.gameObject.GetComponent<EnemyScript>();
            enemyScript.TakeDamage(bulletDmg);
            enemyScript.TakeKnockback(bulletKnockback);
        }
        GameObject bulletExpClone = Instantiate(bulletExplosionPart, transform.position, transform.rotation);
        Destroy(bulletExpClone, 1f);
        Destroy(this.gameObject);
    }
}
