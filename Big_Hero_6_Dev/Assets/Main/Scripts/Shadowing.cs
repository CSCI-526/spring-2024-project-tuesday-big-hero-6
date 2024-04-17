using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using System;
public class PlayerPositon
{
    public string level;
    public string eventName;
    public double posX_Shadowing;
    public double posY_Shadowing;
     public long timeStamp;
}
public class Shadowing : MonoBehaviour
{
    public GameObject shadowPrefab; // Shadow Prefab
    public GameObject shadowInstance; // Shadow Instance
    private List<Vector3> positionList = new List<Vector3>(); // Shadow Position List
    public float shadowDelay = 1f; // Shadow Lag Time
    private float timer = 0f; // TImer
    private float recordInterval = 0.01f; // Position Inverval
    private int Renderindex;
    private int Moveindex;
    public int gelFlag = 0;
    public float shadowIndex = 1.2f;
    private LevelAnalyticsManager levelAnalyticsManager;
    private double posX_shadowing;
    private double posY_shadowing;
    void Start()
    {
        shadowInstance = Instantiate(shadowPrefab, transform.position, Quaternion.identity);
        levelAnalyticsManager = FindObjectOfType<LevelAnalyticsManager>();
    }

    public long GetTimeStamp()
    {
        DateTime now = DateTime.UtcNow;
        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        TimeSpan timeSpan = now - epoch;
        long timestampSeconds = (long)timeSpan.TotalSeconds;
        return timestampSeconds;
    }

    void Update()
    {
        RecordPosition();
        RenderShadow();

        if (Input.GetKeyDown(KeyCode.J) && !Global.gamePause && SaveManager.Instance.CanPressJ() )
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
        if (gelFlag == 0)
        {
            if (positionList.Count > shadowDelay / recordInterval)
            {
                Renderindex = Mathf.Max(0,positionList.Count - Mathf.FloorToInt(shadowDelay / recordInterval)); // Reder shadow's position
                shadowInstance.transform.position = positionList[Renderindex];
            }
        }
        else
        {
            if (positionList.Count > shadowDelay / recordInterval)
            {
                Renderindex = Mathf.Max(0, positionList.Count - Mathf.FloorToInt(shadowIndex / recordInterval)); // Reder shadow's position
                shadowInstance.transform.position = positionList[Renderindex];
            }
        }
    }

    void MoveToShadowPosition()
    {
        if (positionList.Count > shadowDelay / recordInterval)
        {
            //Moveindex = Mathf.Max(0, positionList.Count - Mathf.FloorToInt(shadowDelay / recordInterval)); //Get shadow's position
            //transform.position = positionList[Moveindex];
            var player_Position = transform.position;
            transform.position = shadowInstance.transform.position;
            positionList.Clear(); // Clear old shadow's position
            
            positionList.Add(transform.position); // Restart the shddow
            posX_shadowing = player_Position.x;
            posY_shadowing = player_Position.y;
            string currentLevelIndex = levelAnalyticsManager != null ? levelAnalyticsManager.LevelIndex : "Unknown";
            string levelTimeEvent = "FinishLevel" + currentLevelIndex;
            Debug.Log(currentLevelIndex);
            if (currentLevelIndex == "1")
            {
                PlayerPositon playerPositon = new PlayerPositon();
                playerPositon.level = "Level1";
                playerPositon.eventName = "Level1_PlayerPositon_Shadowing";
                playerPositon.posX_Shadowing = posX_shadowing;
                playerPositon.posY_Shadowing = posY_shadowing;
                playerPositon.timeStamp = GetTimeStamp();
                string json = JsonUtility.ToJson(playerPositon);
                RestClient.Post("https://big-hero-6-1efc3-default-rtdb.firebaseio.com/.json", playerPositon);
            }
            else if (currentLevelIndex == "2")
            {
                PlayerPositon playerPositon = new PlayerPositon();
                playerPositon.level = "Level1";
                playerPositon.eventName = "Level2_PlayerPositon_Shadowing";
                playerPositon.posX_Shadowing = posX_shadowing;
                playerPositon.posY_Shadowing = posY_shadowing;
                playerPositon.timeStamp = GetTimeStamp();
                string json = JsonUtility.ToJson(playerPositon);
                RestClient.Post("https://big-hero-6-1efc3-default-rtdb.firebaseio.com/.json", playerPositon);
            }
            else if (currentLevelIndex == "3")
            {
                PlayerPositon playerPositon = new PlayerPositon();
                playerPositon.level = "Level3";
                playerPositon.eventName = "Level3_PlayerPositon_Shadowing";
                playerPositon.posX_Shadowing = posX_shadowing;
                playerPositon.posY_Shadowing = posY_shadowing;
                playerPositon.timeStamp = GetTimeStamp();
                string json = JsonUtility.ToJson(playerPositon);
                RestClient.Post("https://big-hero-6-1efc3-default-rtdb.firebaseio.com/.json", playerPositon);
            }
        }
    }
}