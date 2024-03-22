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
        if (other.gameObject.CompareTag("Player") && Global.yellowKey && Global.redKey)
        {
            if(currentScene.name !="Tutorial1" && currentScene.name != "Tutorial2"){
                levelAnalyticsManager.EndLevel();
            }
            Debug.Log("Game Over. You Succeed!");
            Time.timeScale = 0;
            Global.gamePause = true;
            winGameObject.SetActive(true);
        }
    }
}
