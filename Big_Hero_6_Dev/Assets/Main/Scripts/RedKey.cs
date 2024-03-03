using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedKey : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Global.redKey = true;

            GameObject[] floors = GameObject.FindGameObjectsWithTag("Floor");
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
            foreach(GameObject gel in gels)
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
