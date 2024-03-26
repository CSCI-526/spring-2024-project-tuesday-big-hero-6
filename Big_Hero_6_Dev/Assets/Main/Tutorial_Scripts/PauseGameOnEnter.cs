using UnityEngine;
using UnityEngine.SceneManagement; 
public class PauseGameOnEnter_Tutorial : MonoBehaviour
{
    public GameObject winGameObject;
    public static bool gamePause = false;
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        
        Debug.Log("Current Scene is: " + currentScene.name);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Tutorial1")
        {
            Global.tutorial1 = true;
            Global.showTutorial2 = true;
            Debug.Log("Global tutorial1 changed!");
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Game Over. You Succeed!");
            Time.timeScale = 0;
            gamePause = true;
            winGameObject.SetActive(true);
        }
    }
}
