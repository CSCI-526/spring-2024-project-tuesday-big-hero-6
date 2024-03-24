using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseGame : MonoBehaviour
{
    public float pauseThreshold = -10f;

    public GameObject loseGameObject;

    void Update()
    {
        if (transform.position.y < pauseThreshold)
        {
            Time.timeScale = 0;
            Global.gamePause = true;
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
