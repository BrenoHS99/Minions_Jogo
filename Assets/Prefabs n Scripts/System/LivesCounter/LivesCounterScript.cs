using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class LivesCounterScript : MonoBehaviour
{
    private TextMeshProUGUI txt;

    private void Start()
    {
        txt = GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        txt.text = "x" + GameManager.Instance.lives;
    }
}
