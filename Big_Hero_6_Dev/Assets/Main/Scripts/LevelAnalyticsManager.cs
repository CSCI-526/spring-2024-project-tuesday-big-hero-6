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
}
public class LevelAnalyticsManager : MonoBehaviour
{
    private float levelStartTime;
    private string levelIndex;

    void Start()
    {
        string pattern = @"\d+";

        MatchCollection matches = Regex.Matches(SceneManager.GetActiveScene().name, pattern);
        levelIndex = matches[matches.Count - 1].Value;
        Debug.Log(levelIndex);
        StartLevel();
    }

    public void StartLevel()
    {
        // Level Start
        levelStartTime = Time.time;
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

    public void EndLevel()
    {
        // Level End
        float levelEndTime = Time.time;
        Debug.Log("End Time: " + levelEndTime);
        float timeToComplete = levelEndTime - levelStartTime;
        string levelTimeEvent = "FinishLevel" + levelIndex;
        Debug.Log(levelIndex);
        if (levelIndex == "1")
        {
            FinishLevelTime finishLevelTime = new FinishLevelTime();
            finishLevelTime.level = "Level1";
            finishLevelTime.eventName = "Level1_FinishTime";
            finishLevelTime.time = timeToComplete;
            finishLevelTime.timeStamp = GetTimeStamp();
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
        else if (levelIndex == "2")
        {
            FinishLevelTime finishLevelTime = new FinishLevelTime();
            finishLevelTime.level = "Level2";
            finishLevelTime.eventName = "Level2_FinishTime";
            finishLevelTime.time = timeToComplete;
            finishLevelTime.timeStamp = GetTimeStamp();
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
        else if (levelIndex == "3")
        {
            FinishLevelTime finishLevelTime = new FinishLevelTime();
            finishLevelTime.level = "Level3";
            finishLevelTime.eventName = "Level3_FinishTime";
            finishLevelTime.time = timeToComplete;
            finishLevelTime.timeStamp = GetTimeStamp();
            string json = JsonUtility.ToJson(finishLevelTime);
            RestClient.Post("https://big-hero-6-1efc3-default-rtdb.firebaseio.com/.json", finishLevelTime);
        }

        
        Debug.Log("Level end analytics result: " + timeToComplete);
    }
}