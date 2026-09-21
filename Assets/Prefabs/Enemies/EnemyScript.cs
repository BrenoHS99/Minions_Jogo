using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Configurations
    public float enemyHP;
    public float enemySpeed;
    public float knockbackMultiplier;

    public float followingRange;
    public float attackRange;

    public GameObject enemyPunchHitbox;
    private bool canAttack = true;

    public GameObject enemyRig;

    // Player
    private GameObject plr;

    // Components
    private Rigidbody rb;

    private Animator enemyAnim;

    void Start()
    {
        plr = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();

        enemyAnim = enemyRig.GetComponent<Animator>();
    }

    void Update()
    {
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
        }

        if((plr.transform.position - transform.position).magnitude <= followingRange && canAttack == true)
        {
            enemyAnim.SetBool("running", true);
            Vector3 plrXZPos = new Vector3(plr.transform.position.x, transform.position.y, plr.transform.position.z);
            transform.LookAt(plrXZPos);
            rb.MovePosition(rb.position + transform.forward * enemySpeed * Time.deltaTime);
        }
        else
        {
            enemyAnim.SetBool("running", false);
        }

        if ((plr.transform.position - transform.position).magnitude <= attackRange && canAttack == true)
        {
            StartCoroutine(EnemyAttack("punch"));
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
                enemyAnim.SetTrigger("melee");

                yield return new WaitForSeconds(0.5f); // Delay for Attack
                enemyPunchHitbox.SetActive(true);

                yield return new WaitForSeconds(0.1f); // Hitbox active time
                enemyPunchHitbox.SetActive(false);

                yield return new WaitForSeconds(2f); // Cooldown
                canAttack = true;
            }
        }
    }
}
