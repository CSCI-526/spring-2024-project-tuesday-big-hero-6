using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shadowing : MonoBehaviour
{
    public GameObject shadowPrefab; // Shadow Prefab
    private GameObject shadowInstance; // Shadow Instance
    private List<Vector3> positionList = new List<Vector3>(); // Shadow Position List
    public float shadowDelay = 3f; // Shadow Lag Time
    private float timer = 0f; // TImer
    private float recordInterval = 0.01f; // Position Inverval

    void Start()
    {
        shadowInstance = Instantiate(shadowPrefab, transform.position, Quaternion.identity);
    }

    void Update()
    {
        RecordPosition();
        RenderShadow();

        if (Input.GetKeyDown(KeyCode.J))
        {
            MoveToShadowPosition(); // Go back to the shadow
        }
    }

    void RecordPosition()
    {
        timer += Time.deltaTime;
        if (timer >= recordInterval)
        {
            positionList.Add(transform.position); // Record the shadow position
            timer = 0f;
        }
    }

    void RenderShadow()
    {
        if (positionList.Count > shadowDelay / recordInterval)
        {
            int index = Mathf.Max(0, positionList.Count - Mathf.FloorToInt(shadowDelay / recordInterval)); // Reder shadow's position
            shadowInstance.transform.position = positionList[index];
        }
    }

    void MoveToShadowPosition()
    {
        if (positionList.Count > shadowDelay / recordInterval)
        {
            int index = Mathf.Max(0, positionList.Count - Mathf.FloorToInt(shadowDelay / recordInterval)); //Get shadow's position
            transform.position = positionList[index];
            
            positionList.Clear(); // Clear old shadow's position
            
            positionList.Add(transform.position); // Restart the shddow
        }
    }
}