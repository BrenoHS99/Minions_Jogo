using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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

    private float playerHpPercent;

    // Components
    private CharacterChanging characterScript;

    // Canvas
    public GameObject sliderObj;
    private Slider canvasSlider;

    // SFXManager

    private GameObject SFXmanager;

    private GameObject hurtSfx;
    private AudioSource hurtAudio;

    void Start()
    {
        // Components
        characterScript = GetComponent<CharacterChanging>();

        canvasSlider = sliderObj.GetComponent<Slider>();

        SFXmanager = GameObject.FindWithTag("SFXManager");

        hurtSfx = SFXmanager.transform.Find("Hurt").gameObject;

        hurtAudio = hurtSfx.GetComponent<AudioSource>();
    }

    void Update()
    {
        // Player HP for different characters
        if (characterScript.currentChar == "k")
        {
            playerHP = kevinHP;
            playerHpPercent = playerHP / kevinMaxHP;
        }
        if (characterScript.currentChar == "b")
        {
            playerHP = bobHP;
            playerHpPercent = playerHP / bobMaxHP;
        }
        if (characterScript.currentChar == "s")
        {
            playerHP = stuartHP;
            playerHpPercent = playerHP / stuartMaxHP;
        }
        canvasSlider.value = playerHpPercent;

        if (kevinHP <= 0 && characterScript.currentChar == "k")
        {
            characterScript.ForceChangeChar("s");
        }
        if (bobHP <= 0 && characterScript.currentChar == "b")
        {
            characterScript.ForceChangeChar("k");
        }
        if (stuartHP <= 0 && characterScript.currentChar == "s")
        {
            characterScript.ForceChangeChar("k");
        }
        if (stuartHP <= 0 && kevinHP <= 0)
        {
            GameManager.Instance.loseLife();
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            if (characterScript.currentChar == "k")
            {
                kevinHP = 0;
            }
            if (characterScript.currentChar == "b")
            {
                bobHP = 0;
            }
            if (characterScript.currentChar == "s")
            {
                stuartHP = 0;
            }
        }
    }

    public void TakeDamage(float dmg)
    {
        hurtAudio.PlayOneShot(hurtAudio.clip);
        if (characterScript.currentChar == "k")
        {
            kevinHP -= dmg;
        }
        if (characterScript.currentChar == "b")
        {
            bobHP -= dmg;
        }
        if (characterScript.currentChar == "s")
        {
            stuartHP -= dmg;
        }
    }
}
