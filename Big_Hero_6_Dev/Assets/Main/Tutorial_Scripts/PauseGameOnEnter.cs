using UnityEngine;
using UnityEngine.SceneManagement; 
public class PauseGameOnEnter_Tutorial : MonoBehaviour
{
    public GameObject winGameObject;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        
        Debug.Log("Current Scene is: " + currentScene.name);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over. You Suscceed!");
            Time.timeScale = 0;
            winGameObject.SetActive(true);
        }
    }
}
