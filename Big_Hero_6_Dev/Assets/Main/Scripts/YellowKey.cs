using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class YellowKey : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {

        Scene currentScene = SceneManager.GetActiveScene();

        if (collision.gameObject.CompareTag("Player"))
        {
            Global.yellowKey = true;
            GameObject[] keyCounts = GameObject.FindGameObjectsWithTag("KeyCount");
            Image[] keyCountImages = new Image[keyCounts.Length];
            for (int i = 0; i < keyCounts.Length; i++)
            {
                keyCountImages[i] = keyCounts[i].GetComponent<Image>();
            }
            keyCountImages[Global.keyNum].color = new Color32(255, 255, 255, 255);
            Global.keyNum++;

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
