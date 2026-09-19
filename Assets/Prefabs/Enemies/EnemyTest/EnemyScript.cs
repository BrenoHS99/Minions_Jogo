using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Configurations
    public float enemyHP;
    public float enemySpeed;
    public float knockbackMultiplier;

    public string enemyType;
    public GameObject enemyPunchHitbox;
    private bool canAttack = true;

    // Player
    private GameObject plr;

    // Components
    private Rigidbody rb;

    void Start()
    {
        plr = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
        }

        if((plr.transform.position - transform.position).magnitude <= 10 && canAttack == true)
        {
            Vector3 plrXZPos = new Vector3(plr.transform.position.x, transform.position.y, plr.transform.position.z);
            transform.LookAt(plrXZPos);
            rb.MovePosition(rb.position + transform.forward * enemySpeed * Time.deltaTime);
        }

        if(enemyType == "test")
        {
            if ((plr.transform.position - transform.position).magnitude <= 3 && canAttack == true)
            {
                StartCoroutine(EnemyAttack("punch"));
            }
        }
    }

    public void TakeKnockback(float knockbackAmount)
    {
        rb.MovePosition(rb.position + ((transform.forward * knockbackAmount * -1) * knockbackMultiplier) * Time.deltaTime);
    }

    public void TakeDamage(float dmgAmount)
    {
        enemyHP -= dmgAmount;
    }

    IEnumerator EnemyAttack(string attackType)
    {
        if (canAttack)
        {
            if (attackType == "punch")
            {
                canAttack = false;

                yield return new WaitForSeconds(0.5f); // Delay for Attack
                enemyPunchHitbox.SetActive(true);

                yield return new WaitForSeconds(0.1f); // Hitbox active time
                enemyPunchHitbox.SetActive(false);

                yield return new WaitForSeconds(1f); // Cooldown
                canAttack = true;
            }
        }
    }
}
