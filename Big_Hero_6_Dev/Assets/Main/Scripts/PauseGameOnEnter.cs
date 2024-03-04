using UnityEngine;
using UnityEngine.SceneManagement; 
public class PauseGameOnEnter : MonoBehaviour
{
    public GameObject winGameObject;

	void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        Debug.Log("Current scene is : " + currentScene.name);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Global.yellowKey && Global.redKey)
        {
            Debug.Log("Game Over. You Suscceed!");
            Time.timeScale = 0;
            winGameObject.SetActive(true);
        }
    }
}
