using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class PrimaryAttack : MonoBehaviour
{
    // Heat Bullet
    public GameObject heatBullet;
    public Transform heatBulletSpawnPos;

    // Character Changing Script
    private CharacterChanging charChangeScript;

    // Other
    private bool canAttack = true;

    void Start()
    {
        charChangeScript = GetComponent<CharacterChanging>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            StartCoroutine(ActivateAttack());
        }
    }

    IEnumerator ActivateAttack()
    {
        if (canAttack)
        {
            canAttack = false;
            if (charChangeScript.currentChar == "k")
            {
                Instantiate(heatBullet, heatBulletSpawnPos.position, heatBulletSpawnPos.rotation);

                yield return new WaitForSeconds(1f);
                canAttack = true;
            }
            if (charChangeScript.currentChar == "b")
            {

            }
            if (charChangeScript.currentChar == "s")
            {

            }
        }
    }
}
