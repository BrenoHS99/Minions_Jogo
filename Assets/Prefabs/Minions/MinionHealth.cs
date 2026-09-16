using UnityEngine;

public class MinionHealth : MonoBehaviour
{
    // Characters Current Health
    public float kevinHP;
    public float stuartHP;
    public float bobHP;

    public float playerHP;

    // Characters Max Health
    public float kevinMaxHP;
    public float stuartMaxHP;
    public float bobMaxHP;

    // Components
    private CharacterChanging characterScript;

    void Start()
    {
        // Components
        characterScript = GetComponent<CharacterChanging>();
    }

    void Update()
    {
        // Player HP for different characters
        if (characterScript.currentChar == "k")
        {
            playerHP = kevinHP;
        }
        if (characterScript.currentChar == "b")
        {
            playerHP = bobHP;
        }
        if (characterScript.currentChar == "s")
        {
            playerHP = stuartHP;
        }
    }
}
