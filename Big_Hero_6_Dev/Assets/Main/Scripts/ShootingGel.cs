using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Proyecto26;
using System;
public class PlayerPositon_TimeGel
{
    public string level;
    public string eventName;
    public double posX_TimeGel;
    public double posY_TimeGel;
    public long timeStamp;
}

public class ShootingGel : MonoBehaviour
{
    public GameObject objectToShoot;
    public float shootForce = 1000f;
    public Transform shootPointForward;
    public Transform shootPointBackward;
    public Transform shootPointUpside;
    public Transform shootPointDownside;
    private float horizontalInput;
    private float verticalInput;
    public int shootNum = 1;
    public GameObject shotObject;
    private bool gelStatus = true;
    private LevelAnalyticsManager levelAnalyticsManager;
    private double posX_timegel;
    private double posY_timegel;
    
    void Start()
    {

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
        
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        /*Debug.Log(horizontalInput);
        Debug.Log(verticalInput);*/

        if (Input.GetKeyDown(KeyCode.K) && !Global.gamePause)
        {
            if (shootNum == 1)
            {
                ProgressBar progressBar = GetComponent<ProgressBar>();
                progressBar.ResetAndFillProgressBar();
            }
            Shoot();
        }
    }
    IEnumerator setGelNumBack()
    {
        yield return new WaitForSeconds(5);
        shootNum = 1;
        gelStatus = true;

    }

    void Shoot()
    {
        var player_Position = transform.position;
        posX_timegel = player_Position.x;
        posY_timegel = player_Position.y;
        string currentLevelIndex = levelAnalyticsManager != null ? levelAnalyticsManager.LevelIndex : "Unknown";
        string levelTimeEvent = "FinishLevel" + currentLevelIndex;
        Debug.Log(currentLevelIndex);
        if (currentLevelIndex == "2")
        {
            PlayerPositon_TimeGel playerPositon_timegel = new PlayerPositon_TimeGel();
            playerPositon_timegel.level = "Level2";
            playerPositon_timegel.eventName = "Level2_PlayerPositon_TimeGel";
            playerPositon_timegel.posX_TimeGel = posX_timegel;
            playerPositon_timegel.posY_TimeGel = posY_timegel;
            playerPositon_timegel.timeStamp = GetTimeStamp();
            string json = JsonUtility.ToJson(playerPositon_timegel);
            RestClient.Post("https://big-hero-6-1efc3-default-rtdb.firebaseio.com/.json", playerPositon_timegel);
        }
        else if (currentLevelIndex == "3")
        {
            PlayerPositon_TimeGel playerPositon_timegel = new PlayerPositon_TimeGel();
            playerPositon_timegel.level = "Level3";
            playerPositon_timegel.eventName = "Level3_PlayerPositon_TimeGel";
            playerPositon_timegel.posX_TimeGel = posX_timegel;
            playerPositon_timegel.posY_TimeGel = posY_timegel;
            playerPositon_timegel.timeStamp = GetTimeStamp();
            string json = JsonUtility.ToJson(playerPositon_timegel);
            RestClient.Post("https://big-hero-6-1efc3-default-rtdb.firebaseio.com/.json", playerPositon_timegel);
        }

        if (shootNum == 1)
        {
            if (horizontalInput >= 0 && verticalInput == 0)
            {
                shotObject =
                    Instantiate(objectToShoot, shootPointForward.position, shootPointForward.rotation);
                shootNum = 0;
                if (shotObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    rb.AddForce(shootPointForward.forward * shootForce);
                }

                Destroy(shotObject, 5f);
                StartCoroutine(setGelNumBack());
            }
            else if (horizontalInput < 0)
            {
                shotObject =
                    Instantiate(objectToShoot, shootPointBackward.position, shootPointBackward.rotation);
                shootNum = 0;
                if (shotObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    rb.AddForce(shootPointBackward.forward * shootForce);
                }

                Destroy(shotObject, 5f);
                StartCoroutine(setGelNumBack());
            }
            else if (verticalInput > 0)
            {
                shotObject =
                    Instantiate(objectToShoot, shootPointUpside.position, shootPointUpside.rotation);
                shootNum = 0;
                if (shotObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    rb.AddForce(shootPointUpside.forward * shootForce);
                }

                Destroy(shotObject, 5f);
                StartCoroutine(setGelNumBack());
            }
            else if (verticalInput < 0)
            {
                shotObject =
                    Instantiate(objectToShoot, shootPointDownside.position, shootPointDownside.rotation);
                shootNum = 0;
                if (shotObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    rb.AddForce(shootPointDownside.forward * shootForce);
                }

                Destroy(shotObject, 5f);
                StartCoroutine(setGelNumBack());
            }
        }
    }
}
