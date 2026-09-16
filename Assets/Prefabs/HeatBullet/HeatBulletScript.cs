using UnityEngine;

public class HeatBulletScript : MonoBehaviour
{
    public float bulletSpeed;

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
        Destroy(this.gameObject);
    }
}
