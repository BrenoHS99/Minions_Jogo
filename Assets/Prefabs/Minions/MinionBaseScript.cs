using UnityEngine;

public class MinionBaseScript : MonoBehaviour
{
    private GameObject camera;

    public float speed;

    public GameObject front;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        camera = GameObject.FindWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.rotation = Quaternion.Euler(0,0,0);
            transform.position += transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
			transform.rotation = Quaternion.Euler(0, -90, 0);
			transform.position += transform.forward * speed;
		}

		if (Input.GetKey(KeyCode.S))
		{
			transform.rotation = Quaternion.Euler(0, 180, 0);
			transform.position += transform.forward * speed;
		}

		if (Input.GetKey(KeyCode.D))
		{
			transform.rotation = Quaternion.Euler(0, 90, 0);
			transform.position += transform.forward * speed;
		}
	}
}
