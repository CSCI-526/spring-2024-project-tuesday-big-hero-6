using UnityEngine;
using UnityEngine.SceneManagement; 
public class PauseGameOnEnter : MonoBehaviour
{
    public GameObject winGameObject;
	public LevelAnalyticsManager levelAnalyticsManager;

	void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        Debug.Log("Current scene is : " + currentScene.name);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        Scene currentScene = SceneManager.GetActiveScene();

        if (other.gameObject.CompareTag("Player") && currentScene.name == "Tutorial1")
        {
            Debug.Log("Game Over. You Succeed!");
            Time.timeScale = 0;
            Global.gamePause = true;
            winGameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("Player") && currentScene.name == "Tutorial2" && Global.keyNum == 2)
        {
            Global.tutorial2 = true;
            levelAnalyticsManager.EndLevel();
            Debug.Log("Game Over. You Succeed!");
            Time.timeScale = 0;
            Global.gamePause = true;
            winGameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("Player") && currentScene.name == "Tutorial3" && Global.keyNum == 2)
        {
            //Global.tutorial2 = true;
            Debug.Log("Global tutorial2 changed!");
            Debug.Log("Game Over. You Succeed!");
            Time.timeScale = 0;
            Global.gamePause = true;
            winGameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("Player") && (currentScene.name == "Level 1" || currentScene.name == "Level 2" || currentScene.name == "Level 3") && Global.keyNum == 2)
        {
            levelAnalyticsManager.EndLevel();
            Debug.Log("Game Over. You Succeed!");
            Time.timeScale = 0;
            Global.gamePause = true;
            winGameObject.SetActive(true);
        }
        /**
        if (other.gameObject.CompareTag("Player") && currentScene.name == "Level 2" && Global.keyNum == 2)
        {
            levelAnalyticsManager.EndLevel();
            Debug.Log("Game Over. You Succeed!");
            Time.timeScale = 0;
            Global.gamePause = true;
            winGameObject.SetActive(true);
        }
        if (other.gameObject.CompareTag("Player") && currentScene.name == "Level 3" && Global.keyNum >=2)
        {
            levelAnalyticsManager.EndLevel();
            Debug.Log("Game Over. You Succeed!");
            Time.timeScale = 0;
            Global.gamePause = true;
            winGameObject.SetActive(true);
        }
        */
        if (other.gameObject.CompareTag("Player") && currentScene.name == "Level 4" && Global.keyNum == 3)
        {
            levelAnalyticsManager.EndLevel();
            Debug.Log("Game Over. You Succeed!");
            Time.timeScale = 0;
            Global.gamePause = true;
            winGameObject.SetActive(true);
        }

        /**
        if (other.gameObject.CompareTag("Player") && Global.yellowKey && Global.redKey)
        {
            if (currentScene.name != "Tutorial1" && currentScene.name != "Tutorial2"){
                levelAnalyticsManager.EndLevel();
            }
            
            if (currentScene.name == "Tutorial2")
            {
                Global.tutorial2 = true;
                Debug.Log("Global tutorial2 changed!");
            }
            Debug.Log("Game Over. You Succeed!");
            Time.timeScale = 0;
            Global.gamePause = true;
            winGameObject.SetActive(true);
            
            
        }
        */

    }
}
