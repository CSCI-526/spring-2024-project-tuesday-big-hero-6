using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LoseGame : MonoBehaviour
{
    public float pauseThreshold = -10f;

    public GameObject loseGameObject;


    void Update()
    {
        if (transform.position.y < pauseThreshold)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            Debug.Log("Current Scene is: " + currentScene.name);
            Global.gamePause = true;
            PauseGameOnEnter_Tutorial.gamePause = true;
            loseGameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap"))
        {
            Time.timeScale = 0;
            Global.gamePause = true;
            loseGameObject.SetActive(true);
        }

    }

}
