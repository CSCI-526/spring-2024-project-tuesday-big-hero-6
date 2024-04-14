using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class KeyCount : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        keyCountMethod();
    }

    public void keyCountMethod()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        GameObject[] keyCounts = GameObject.FindGameObjectsWithTag("KeyCount");
        Image[] keyCountImages = new Image[keyCounts.Length];
        for (int i = 0; i < keyCounts.Length; i++)
        {
            keyCountImages[i] = keyCounts[i].GetComponent<Image>();
        }
        foreach (Image img in keyCountImages)
        {
            img.gameObject.SetActive(false);
        }
        /**
        foreach (GameObject keyCount in keyCounts)
        {
            if(keyCount != null)
            {
                keyCount.gameObject.SetActive(false);
            }
        }
        */

        if (currentScene.name == "Tutorial1")
        {

        }
        if (currentScene.name == "Tutorial2")
        {
            Debug.Log("This is tutorial 2! Key Count Script!");
            for (global::System.Int32 i = 0; i < 2; i++)
            {
                Debug.Log("Set " + i + " key active!");
                //keyCounts[i].SetActive(true);
                keyCountImages[keyCounts.Length - i - 1].gameObject.SetActive(true);
                //keyCountImages[keyCounts.Length - i - 1].color = new Color32(255, 255, 255, 255);
            }
        }
        if (currentScene.name == "Tutorial3")
        {
            Debug.Log("This is tutorial 2! Key Count Script!");
            for (global::System.Int32 i = 0; i < 2; i++)
            {
                Debug.Log("Set " + i + " key active!");
                //keyCounts[i].SetActive(true);
                keyCountImages[keyCounts.Length - i - 1].gameObject.SetActive(true);
                //keyCountImages[keyCounts.Length - i - 1].color = new Color32(255, 255, 255, 255);
            }
        }
        if (currentScene.name == "Level 1")
        {
            Debug.Log("This is Level 1! Key Count Script!");
            for (global::System.Int32 i = 0; i < 2; i++)
            {
                Debug.Log("Set " + i + " key active!");
                //keyCounts[i].SetActive(true);
                keyCountImages[keyCounts.Length - i - 1].gameObject.SetActive(true);
                //keyCountImages[keyCounts.Length - i - 1].color = new Color32(255, 255, 255, 255);
            }
        }
        if (currentScene.name == "Level 2")
        {
            Debug.Log("This is Level 2! Key Count Script!");
            for (global::System.Int32 i = 0; i < 2; i++)
            {
                Debug.Log("Set " + i + " key active!");
                //keyCounts[i].SetActive(true);
                keyCountImages[keyCounts.Length - i - 1].gameObject.SetActive(true);
                //keyCountImages[keyCounts.Length - i - 1].color = new Color32(255, 255, 255, 255);
            }
        }
        if (currentScene.name == "Level 3")
        {
            Debug.Log("This is Level 3! Key Count Script!");
            for (global::System.Int32 i = 0; i < 2; i++)
            {
                Debug.Log("Set " + i + " key active!");
                //keyCounts[i].SetActive(true);
                keyCountImages[keyCounts.Length - i - 1].gameObject.SetActive(true);
                //keyCountImages[keyCounts.Length - i - 1].color = new Color32(255, 255, 255, 255);
            }
        }
        if (currentScene.name == "Level 4")
        {
            Debug.Log("This is Level 3! Key Count Script!");
            for (global::System.Int32 i = 0; i < 3; i++)
            {
                Debug.Log("Set " + i + " key active!");
                //keyCounts[i].SetActive(true);
                keyCountImages[keyCounts.Length - i - 1].gameObject.SetActive(true);
                //keyCountImages[keyCounts.Length - i - 1].color = new Color32(255, 255, 255, 255);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
