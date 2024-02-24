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

            GameObject floor = GameObject.FindGameObjectWithTag("Floor");
            if (floor != null)
            {
                Destroy(floor);
                Debug.Log("Floor has been destroyed!");
            }

            Destroy(gameObject);
            Debug.Log("Red key has been collected!");
        }
    }
}