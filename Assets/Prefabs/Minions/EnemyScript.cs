using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    // Configurations
    public float enemyHP;


    void Start()
    {
        
    }

    void Update()
    {
        if (enemyHP <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(float dmgAmount)
    {
        enemyHP -= dmgAmount;
    }
}
