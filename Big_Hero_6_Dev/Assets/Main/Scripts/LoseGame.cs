using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Proyecto26;
using System;
public class DeathType
{
    public string level;
    public string eventName;
    public string fall;
    public string arrow;
    public string thorn;
    public long timeStamp;
}

public class LoseGame : MonoBehaviour
{
    public float pauseThreshold = -10f;

    public GameObject loseGameObject;
    private LevelAnalyticsManager levelAnalyticsManager;
    //public bool deathHandled = false;

    void Start()
    {

        levelAnalyticsManager = FindObjectOfType<LevelAnalyticsManager>();
        Debug.Log(Global.deathHandled);

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

        Debug.Log(Global.deathHandled);
        Debug.Log(transform.position.y);
        Debug.Log(pauseThreshold);
        if (!Global.deathHandled && (transform.position.y < pauseThreshold))
        {
            Debug.Log("HandleDeath");
            HandleDeath();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collide");
        if (!Global.deathHandled && other.CompareTag("Trap"))
        {
            Time.timeScale = 0;
            Global.gamePause = true;
            // loseGameObject.SetActive(true);
            string currentLevelIndex = levelAnalyticsManager != null ? levelAnalyticsManager.LevelIndex : "Unknown";
            Debug.Log(currentLevelIndex);
            if (currentLevelIndex == "3")
            {
                DeathType deathtype = new DeathType();
                deathtype.level = "Level3";
                deathtype.eventName = "Level3_DeathType";
                deathtype.fall = "No";
                deathtype.arrow = "Yes";
                deathtype.thorn = "No";
                deathtype.timeStamp = GetTimeStamp();
                string json = JsonUtility.ToJson(deathtype);
                RestClient.Post("https://big-hero-6-1efc3-default-rtdb.firebaseio.com/.json", deathtype);
            }
        }
        else if (!Global.deathHandled && other.CompareTag("Thorn"))
        {
            Time.timeScale = 0;
            Global.gamePause = true;
            // loseGameObject.SetActive(true);
            string currentLevelIndex = levelAnalyticsManager != null ? levelAnalyticsManager.LevelIndex : "Unknown";
            Debug.Log(currentLevelIndex);
            if (currentLevelIndex == "3")
            {
                DeathType deathtype = new DeathType();
                deathtype.level = "Level3";
                deathtype.eventName = "Level3_DeathType";
                deathtype.fall = "No";
                deathtype.arrow = "No";
                deathtype.thorn = "Yes";
                deathtype.timeStamp = GetTimeStamp();
                string json = JsonUtility.ToJson(deathtype);
                RestClient.Post("https://big-hero-6-1efc3-default-rtdb.firebaseio.com/.json", deathtype);
            }
            else if (currentLevelIndex == "2"){
                DeathType deathtype = new DeathType();
                deathtype.level = "Level2";
                deathtype.eventName = "Level2_DeathType";
                deathtype.fall = "No";
                deathtype.arrow = "No";
                deathtype.thorn = "Yes";
                deathtype.timeStamp = GetTimeStamp();
                string json = JsonUtility.ToJson(deathtype);
                RestClient.Post("https://big-hero-6-1efc3-default-rtdb.firebaseio.com/.json", deathtype);
            }
        }

        if (!Global.deathHandled && (other.CompareTag("Trap") || other.CompareTag("Thorn")))
        {
            HandleDeath();
        }
    }

    private void HandleDeath()
    {
        Global.gamePause = true;
        if (!Global.deathHandled && (transform.position.y < pauseThreshold))
        {
            Time.timeScale = 0;
            //Global.gamePause = true;
            // loseGameObject.SetActive(true);
            string currentLevelIndex = levelAnalyticsManager != null ? levelAnalyticsManager.LevelIndex : "Unknown";
            Debug.Log(currentLevelIndex);
            if (currentLevelIndex == "1")
            {
                DeathType deathtype = new DeathType();
                deathtype.level = "Level1";
                deathtype.eventName = "Level1_DeathType";
                deathtype.fall = "Yes";
                deathtype.arrow = "No";
                deathtype.thorn = "No";
                deathtype.timeStamp = GetTimeStamp();
                string json = JsonUtility.ToJson(deathtype);
                RestClient.Post("https://big-hero-6-1efc3-default-rtdb.firebaseio.com/.json", deathtype);
            }
            else if (currentLevelIndex == "2")
            {
                DeathType deathtype = new DeathType();
                deathtype.level = "Level2";
                deathtype.eventName = "Level2_DeathType";
                deathtype.fall = "Yes";
                deathtype.arrow = "No";
                deathtype.thorn = "No";
                deathtype.timeStamp = GetTimeStamp();
                string json = JsonUtility.ToJson(deathtype);
                RestClient.Post("https://big-hero-6-1efc3-default-rtdb.firebaseio.com/.json", deathtype);
            }
            else if (currentLevelIndex == "3")
            {
                DeathType deathtype = new DeathType();
                deathtype.level = "Level3";
                deathtype.eventName = "Level3_DeathType";
                deathtype.fall = "Yes";
                deathtype.arrow = "No";
                deathtype.thorn = "No";
                deathtype.timeStamp = GetTimeStamp();
                string json = JsonUtility.ToJson(deathtype);
                RestClient.Post("https://big-hero-6-1efc3-default-rtdb.firebaseio.com/.json", deathtype);
            }
        }
        Debug.Log("Hello");
        if (Global.deathHandled) return;
        Debug.Log("World");
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Tutorial1")
        {
            Global.gamePause = true;
            PauseGameOnEnter_Tutorial.gamePause = true;
            loseGameObject.SetActive(true);
        }
        else
        {
            if (SaveManager.Instance.HasCheckpoint())
            {
                Global.deathHandled = true;
                SaveManager.Instance.StartCoroutine(SaveManager.Instance.RespawnPlayer(gameObject));
                Global.gamePause = false;
            }
            else
            {
                Time.timeScale = 0;
                Global.gamePause = true;
                PauseGameOnEnter_Tutorial.gamePause = true;
                Global.deathHandled = true;
                loseGameObject.SetActive(true);
            }
        }
    }

}
