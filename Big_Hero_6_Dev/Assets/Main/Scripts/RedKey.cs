using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RedKey : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Global.redKey = true;
            GameObject[] keyCounts = GameObject.FindGameObjectsWithTag("KeyCount");
            Image[] keyCountImages = new Image[keyCounts.Length];
            for (int i = 0; i < keyCounts.Length; i++)
            {
                keyCountImages[i] = keyCounts[i].GetComponent<Image>();
            }
            keyCountImages[Global.keyNum].color = new Color32(255, 255, 255, 255);
            Global.keyNum++;

            GameObject[] floors = GameObject.FindGameObjectsWithTag("Floor");
            GameObject[] thorns = GameObject.FindGameObjectsWithTag("Thorn Level2");
            GameObject[] gels = GameObject.FindGameObjectsWithTag("TimeGel");
            GameObject[] keys = GameObject.FindGameObjectsWithTag("Key");

            foreach(GameObject floor in floors)
            {
                if (floor != null)
                {
                    Destroy(floor);
                    Debug.Log("Floor has been destroyed!");
                }

            }
            foreach (GameObject thorn in thorns)
            {
                if (thorn != null)
                {
                    Destroy(thorn);
                    Debug.Log("Thorn has been destroyed!");
                }

            }
            foreach (GameObject gel in gels)
            {
                if (gel != null)
                {
                    Destroy(gel);
                    Debug.Log("Gel has been destroyed!");
                }

            }
            
            foreach(GameObject key in keys)
            {
                if (key != null)
                {
                    Destroy(key);
                    Debug.Log("Key has been destroyed!");
                }

            }


            Destroy(gameObject);
            Debug.Log("Red key has been collected!");
        }
    }
}
