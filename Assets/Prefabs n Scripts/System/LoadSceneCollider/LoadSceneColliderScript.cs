using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneColliderScript : MonoBehaviour
{
    public int sceneId;

    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(sceneId);
    }
}
