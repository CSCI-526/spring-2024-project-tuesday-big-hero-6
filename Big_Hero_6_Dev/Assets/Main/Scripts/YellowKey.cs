using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class YellowKey : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Scene currentScene = SceneManager.GetActiveScene();

        if (collision.gameObject.CompareTag("Player"))
        {
            Global.yellowKey = true;

            Destroy(gameObject);

            Debug.Log("Yellow key has been collected!");
        }

        if (currentScene.name == "Level 2")
        {
            Debug.Log("Level two yellow key!");
            ThronController thronController = FindObjectOfType<ThronController>();
            if (thronController != null)
            {
                thronController.isOpening = true;
            }
        }

    }
}
