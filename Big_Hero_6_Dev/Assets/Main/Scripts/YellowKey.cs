using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowKey : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Global.yellowKey = true;

            Destroy(gameObject);

            Debug.Log("Yellow key has been collected!");
        }
    }
}
