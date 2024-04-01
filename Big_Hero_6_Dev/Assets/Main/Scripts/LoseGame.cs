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
            HandleDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trap"))
        {
            HandleDeath();
        }
    }

    private void HandleDeath()
    {
        if (SaveManager.Instance.HasCheckpoint())
        {
            SaveManager.Instance.StartCoroutine(SaveManager.Instance.RespawnPlayer(gameObject));
        }
        else
        {

            Time.timeScale = 0;
            Global.gamePause = true;
            PauseGameOnEnter_Tutorial.gamePause = true;
            loseGameObject.SetActive(true);
        }
    }

}
