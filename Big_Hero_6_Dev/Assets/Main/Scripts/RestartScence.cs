using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScence : MonoBehaviour
{

    public GameObject t1_pauseText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Tutorial1")
        {
            Debug.Log("Restart: " + SceneManager.GetActiveScene().name + "T1!!!!!");
            Global.gamePause = false;
            PauseGameOnEnter_Tutorial.gamePause = false;

            FloorDisappear.isTriggered = false;
            DevPlayerMovement_Tutorial.couldJump = false;

            t1_pauseText.SetActive(false); // give tips

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log(FloorDisappear.isTriggered);
            Debug.Log(DevPlayerMovement_Tutorial.couldJump);
            Time.timeScale = 1;


        }
        else
        {
            Debug.Log("Restart: " + SceneManager.GetActiveScene().name);
            Global.redKey = false;
            Global.yellowKey = false;
            Time.timeScale = 1;
            Global.gamePause = false;
            Global.deathHandled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Debug.Log("Game Restart");
            Debug.Log(Global.deathHandled);
        }

    }
}
