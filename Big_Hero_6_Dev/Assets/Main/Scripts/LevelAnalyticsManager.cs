using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using Unity.Services.Core;
using Unity.Services.Analytics;
using System.Text.RegularExpressions;
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
            CustomEvent FinishLevel1 = new CustomEvent(levelTimeEvent)
            {
                { "level_name", SceneManager.GetActiveScene().name },
                { "end_time", levelEndTime },
                { "time_to_complete", timeToComplete }
            };
            AnalyticsService.Instance.RecordEvent(FinishLevel1);
        }
        else if (levelIndex == "2")
        {
            CustomEvent FinishLevel2 = new CustomEvent(levelTimeEvent)
            {
                { "level_name", SceneManager.GetActiveScene().name },
                { "end_time", levelEndTime },
                { "time_to_complete", timeToComplete }
            };
            AnalyticsService.Instance.RecordEvent(FinishLevel2);
        }

        
        Debug.Log("Level end analytics result: " + timeToComplete);
    }
}