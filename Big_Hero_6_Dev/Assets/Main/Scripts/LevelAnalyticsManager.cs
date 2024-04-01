using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Unity.Services.Core;
using Unity.Services.Analytics;
using System.Text.RegularExpressions;
using Proyecto26;
using System;

[System.Serializable]
public class FinishLevelTime
{
    public string level;
    public string eventName;
    public double time;
    public long timeStamp;
    //public double posX_shadowing;
    //public double posY_shadowing;
}
public class LevelAnalyticsManager : MonoBehaviour
{
    private float levelStartTime;
    //private string levelIndex;
    public string LevelIndex;
    //private double posX_shadowing;
    //private double posY_shadowing;
    //private double posX_TimeGel;
    //private double posY_TimeGel;

    void Start()
    {
        string pattern = @"\d+";

        MatchCollection matches = Regex.Matches(SceneManager.GetActiveScene().name, pattern);
        LevelIndex = matches[matches.Count - 1].Value;
        Debug.Log(LevelIndex);
        StartLevel();
    }

    public void StartLevel()
    {
        // Level Start
        levelStartTime = Time.time;
        // Reset shadowing positions
        //posX_shadowing = 0;
        //posY_shadowing = 0;
        Debug.Log("Start Time: " + levelStartTime);
    }

    public long GetTimeStamp()
    {
        DateTime now = DateTime.UtcNow;
        DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        TimeSpan timeSpan = now - epoch;
        long timestampSeconds = (long)timeSpan.TotalSeconds;
        return timestampSeconds;
    }
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.J))
    //    {
    //        var player_Position = transform.position;
    //        posX_shadowing = player_Position.x;
    //        posY_shadowing = player_Position.y;
    //    }
    //}
    public void EndLevel()
    {
        // Level End
        float levelEndTime = Time.time;
        Debug.Log("End Time: " + levelEndTime);
        float timeToComplete = levelEndTime - levelStartTime;
        string levelTimeEvent = "FinishLevel" + LevelIndex;
        Debug.Log(LevelIndex);
        if (LevelIndex == "1")
        {
            FinishLevelTime finishLevelTime = new FinishLevelTime();
            finishLevelTime.level = "Level1";
            finishLevelTime.eventName = "Level1_FinishTime";
            finishLevelTime.time = timeToComplete;
            finishLevelTime.timeStamp = GetTimeStamp();
            //finishLevelTime.posX_shadowing = posX_shadowing;
            //finishLevelTime.posY_shadowing= posY_shadowing;
            string json = JsonUtility.ToJson(finishLevelTime);
            RestClient.Post("https://big-hero-6-1efc3-default-rtdb.firebaseio.com/.json", finishLevelTime);
            /*CustomEvent FinishLevel1 = new CustomEvent(levelTimeEvent)
            {
                { "level_name", SceneManager.GetActiveScene().name },
                { "end_time", levelEndTime },
                { "time_to_complete", timeToComplete }
            };
            AnalyticsService.Instance.RecordEvent(FinishLevel1);*/
        }
        else if (LevelIndex == "2")
        {
            FinishLevelTime finishLevelTime = new FinishLevelTime();
            finishLevelTime.level = "Level2";
            finishLevelTime.eventName = "Level2_FinishTime";
            finishLevelTime.time = timeToComplete;
            finishLevelTime.timeStamp = GetTimeStamp();
            //finishLevelTime.posX_shadowing = posX_shadowing;
            //finishLevelTime.posY_shadowing = posY_shadowing;
            string json = JsonUtility.ToJson(finishLevelTime);
            RestClient.Post("https://big-hero-6-1efc3-default-rtdb.firebaseio.com/.json", finishLevelTime);
            /*CustomEvent FinishLevel2 = new CustomEvent(levelTimeEvent)
            {
                { "level_name", SceneManager.GetActiveScene().name },
                { "end_time", levelEndTime },
                { "time_to_complete", timeToComplete }
            };
            AnalyticsService.Instance.RecordEvent(FinishLevel2);*/
        }
        else if (LevelIndex == "3")
        {
            FinishLevelTime finishLevelTime = new FinishLevelTime();
            finishLevelTime.level = "Level3";
            finishLevelTime.eventName = "Level3_FinishTime";
            finishLevelTime.time = timeToComplete;
            finishLevelTime.timeStamp = GetTimeStamp();
            //finishLevelTime.posX_shadowing = posX_shadowing;
            //finishLevelTime.posY_shadowing = posY_shadowing;
            string json = JsonUtility.ToJson(finishLevelTime);
            RestClient.Post("https://big-hero-6-1efc3-default-rtdb.firebaseio.com/.json", finishLevelTime);
        }

        
        Debug.Log("Level end analytics result: " + timeToComplete);
    }
}