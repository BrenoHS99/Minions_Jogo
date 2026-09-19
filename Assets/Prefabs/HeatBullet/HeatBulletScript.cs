using UnityEngine;

public class HeatBulletScript : MonoBehaviour
{
    public float bulletSpeed;
    public float bulletKnockback;
    public float bulletDmg;

    public GameObject bulletExplosionPart;

    void Start()
    {
        Destroy(this.gameObject, 3f);
    }

    void Update()
    {
        transform.position += transform.forward * bulletSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyScript enemyScript = other.gameObject.GetComponent<EnemyScript>();
            enemyScript.TakeDamage(bulletDmg);
            enemyScript.TakeKnockback(bulletKnockback);
        }
        GameObject bulletExpClone = Instantiate(bulletExplosionPart, transform.position, transform.rotation);
        Destroy(bulletExpClone, 1f);
        Destroy(this.gameObject);
    }
}
