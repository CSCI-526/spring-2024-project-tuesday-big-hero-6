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
        if (other.gameObject.CompareTag("Player") && Global.yellowKey && Global.redKey)
        {
			levelAnalyticsManager.EndLevel();
            Debug.Log("Game Over. You Succeed!");
            Time.timeScale = 0;
            winGameObject.SetActive(true);
        }
    }
}
