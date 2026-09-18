using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PrimaryAttack : MonoBehaviour
{
    // Minion script components
    private CharacterChanging charChangeScript;
    private MinionBaseScript minionScript;

    // Other
    private bool canAttack = true;
    private bool dashing = false;

    // Components
    private Rigidbody rb;

	// Abilities configurations

	// Kevin

	public GameObject heatBullet;
	public Transform heatBulletSpawnPos;

	// Bob
	public float dashSpeed;
    public float dashTime;
    public LayerMask groundMask;

    // Stuart

    public GameObject punchHitbox;

    void Start()
    {
        charChangeScript = GetComponent<CharacterChanging>();
        minionScript = GetComponent<MinionBaseScript>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Left mouse to activate ability
        if (Input.GetMouseButton(0))
        {
            // Kevin ability
            if (charChangeScript.currentChar == "k")
            {
                StartCoroutine(ActivateAttack("k"));
            }

            // Bob ability
            if (charChangeScript.currentChar == "b")
            {
                StartCoroutine(ActivateAttack("b"));
            }

            // Stuart ability
            if (charChangeScript.currentChar == "s")
            {
                StartCoroutine(ActivateAttack("s"));
            }
        }

        // Dash condition
        if (dashing)
        {
            rb.MovePosition(transform.position += transform.forward * dashSpeed * Time.deltaTime);

            Ray r = new Ray(transform.position, transform.forward);
            if (Physics.Raycast(r, 1f, groundMask))
            {
                dashing = false;
                charChangeScript.canChange = true;
                minionScript.canMoveChar = true;
            }
        }

        // Abilities Coroutine
        IEnumerator ActivateAttack(string charAbility)
        {
            if (canAttack)
            {
                canAttack = false;

                // Kevin ability
                if (charAbility == "k")
                {
                    Instantiate(heatBullet, heatBulletSpawnPos.position, heatBulletSpawnPos.rotation);
                    yield return new WaitForSeconds(1f);
                }

                // Bob ability
                if (charAbility == "b")
                {
                    StartCoroutine(ActivateDash());
                    yield return new WaitForSeconds(1.5f);
                }

                // Stuart ability
                if (charAbility == "s")
                {
                    punchHitbox.SetActive(true);
					yield return new WaitForSeconds(0.2f);
					punchHitbox.SetActive(false);
					yield return new WaitForSeconds(0.3f);
				}
                canAttack = true;
            }
        }

        IEnumerator ActivateDash()
        {
            dashing = true;

            charChangeScript.canChange = false;
            minionScript.canMoveChar = false;

            yield return new WaitForSeconds(dashTime);

            dashing = false;

            charChangeScript.canChange = true;
            minionScript.canMoveChar = true;
        }
    }
}
