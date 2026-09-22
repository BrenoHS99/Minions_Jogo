using UnityEngine;
using UnityEngine.SceneManagement;

public class UIControllerScript : MonoBehaviour
{
    public void closeWindow(GameObject window)
    {
        window.SetActive(false);
    }

    public void changeScene(int sceneId)
    {
        SceneManager.LoadScene(sceneId);
    }
}
