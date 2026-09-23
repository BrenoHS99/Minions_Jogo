using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneColliderScript : MonoBehaviour
{
    public int sceneId;
    public string tagsCondition;

    private void OnTriggerEnter(Collider other)
    {
        if(GameObject.FindGameObjectsWithTag(tagsCondition).Length == 0)
        {
            GameManager.Instance.lives = 3;
            SceneManager.LoadScene(sceneId);
        }
    }
}
