using UnityEngine;

public class EnemyPunchScript : MonoBehaviour
{
    public float punchDmg = 15f;

    public GameObject punchDmgParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.gameObject.SetActive(false);
            MinionHealth minionHp = other.gameObject.GetComponent<MinionHealth>();

            GameObject punchPartClone = Instantiate(punchDmgParticle, other.transform.position, other.transform.rotation);
            Destroy(punchPartClone, 1f);

            minionHp.TakeDamage(punchDmg);
        }
    }
}
