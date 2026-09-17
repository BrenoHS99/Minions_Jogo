using UnityEngine;
using System.Collections;

public class CharacterChanging : MonoBehaviour
{
    public string currentChar;

    // Minions Models
    public GameObject Kevin;
    public GameObject Bob;
    public GameObject Stuart;

    // Components

    private MinionBaseScript plrBaseScript;

    // Configurations
    public bool canChange = true;

    void Start()
    {
        // K = Kevin
        // B = Bob
        // S = Stuart
        if (currentChar != "k" || currentChar != "b" || currentChar != "s")
        {
            currentChar = "k";
        }

        // Components

        plrBaseScript = GetComponent<MinionBaseScript>();
    }

    void Update()
    {
        // Change Characters

        if (Input.GetKeyDown("1"))
        {
            StartCoroutine(ChangeCharacter("k"));
        }
        if (Input.GetKeyDown("2"))
        {
			StartCoroutine(ChangeCharacter("b"));
        }
        if (Input.GetKeyDown("3"))
        {
			StartCoroutine(ChangeCharacter("s"));
        }

        // Characters attributes
        if (currentChar == "k")
        {
            plrBaseScript.initialSpeed = 4;
            plrBaseScript.sprintSpeed = 6;
            plrBaseScript.jumpForce = 8;
        }
        if (currentChar == "b")
        {
            plrBaseScript.initialSpeed = 7;
            plrBaseScript.sprintSpeed = 10;
            plrBaseScript.jumpForce = 4;
        }
        if (currentChar == "s")
        {
            plrBaseScript.initialSpeed = 4;
            plrBaseScript.sprintSpeed = 7;
            plrBaseScript.jumpForce = 5;
        }
    }

    IEnumerator ChangeCharacter(string charChange)
    {
        canChange = false;
        currentChar = charChange;

        // Character Model Changing

        // \_ enabling models
        if (currentChar == "k")
        {
            Kevin.SetActive(true);
        }
        if (currentChar == "b")
        {
            Bob.SetActive(true);
        }
        if (currentChar == "s")
        {
            Stuart.SetActive(true);
        }

        // \_ disabling models
        if (currentChar != "k")
        {
            Kevin.SetActive(false);
        }
        if (currentChar != "b")
        {
            Bob.SetActive(false);
        }
        if (currentChar != "s")
        {
            Stuart.SetActive(false);
        }

        yield return new WaitForSeconds(1f);
        canChange = true;
    }
}
