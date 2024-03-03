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
            loseGameObject.SetActive(true);

        }
    }
}
