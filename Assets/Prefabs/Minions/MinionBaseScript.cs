using Unity.VisualScripting;
using UnityEngine;

public class MinionBaseScript : MonoBehaviour
{
    // Plr Configurations
    public float speed;
    public float initialSpeed;
    public float sprintSpeed;
    public float jumpForce;

    private bool sprinting = false;

    public bool onGround;

    // GameObjects
    private GameObject camera;
    public GameObject front;
    public GameObject groundCheck;

    // Components
    private Rigidbody rb;

    // \_ Camera components
    private Camera cameraComponent;


    // Layers
    public LayerMask groundLayer;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        // Camera
        camera = GameObject.FindWithTag("MainCamera");
        cameraComponent = camera.GetComponent<Camera>();

        // Start Scripts
        speed = initialSpeed;
    }

    void Update()
    {
        // GROUND CHECKER

        Ray ray = new Ray(groundCheck.transform.position, Vector3.down);
        onGround = Physics.Raycast(ray, 0.7f, groundLayer);

        // PLAYER INPUTS

        // WASD
        if (Input.GetKey(KeyCode.W))
        {
            if (Input.GetKey(KeyCode.A)) // ^<
            {
                transform.rotation = Quaternion.Euler(0, -45, 0);
            }
            else if (Input.GetKey(KeyCode.D)) // ^>
            {
                transform.rotation = Quaternion.Euler(0, 45, 0);
            }
            else // ^
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        else if (Input.GetKey(KeyCode.A))
        {
            if (Input.GetKey(KeyCode.S)) // <v
            {
                transform.rotation = Quaternion.Euler(0, -135, 0);
            }
            else if (Input.GetKey(KeyCode.W)) // <^
            {
                transform.rotation = Quaternion.Euler(0, -45, 0);
            }
            else // <
            {
                transform.rotation = Quaternion.Euler(0, -90, 0);
            }
        }

		else if (Input.GetKey(KeyCode.S))
		{
            if (Input.GetKey(KeyCode.A)) // v<
            {
                transform.rotation = Quaternion.Euler(0, -135, 0);
            }
            else if (Input.GetKey(KeyCode.D)) // v>
            {
                transform.rotation = Quaternion.Euler(0, 135, 0);
            }
            else // v
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
        }

		else if (Input.GetKey(KeyCode.D))
		{
            if (Input.GetKey(KeyCode.W)) // >^
            {
                transform.rotation = Quaternion.Euler(0, 45, 0);
            }
            else if (Input.GetKey(KeyCode.S)) // >v
            {
                transform.rotation = Quaternion.Euler(0, 135, 0);
            }
            else // >
            {
                transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            rb.MovePosition(rb.position + transform.forward * speed * Time.deltaTime);
        }
        // Jump

        if (Input.GetKey(KeyCode.Space) && onGround)
        {
            rb.linearVelocity = new Vector3(
                rb.linearVelocity.x,
                1 * jumpForce,
                rb.linearVelocity.z);
        }
	
        // Sprint

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            sprinting = true;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            sprinting = false;
        }

        if (sprinting)
        {
            speed = sprintSpeed;
            cameraComponent.fieldOfView = Mathf.Lerp(cameraComponent.fieldOfView, 70f, 0.8f * Time.deltaTime);
        }
        else
        {
            speed = initialSpeed;
            cameraComponent.fieldOfView = Mathf.Lerp(cameraComponent.fieldOfView, 60f, 10f * Time.deltaTime);
        }

        // Camera lerp

        camera.transform.position = Vector3.Lerp(camera.transform.position, transform.position + new Vector3(0, 6, -7), 0.03f);
    }
}
