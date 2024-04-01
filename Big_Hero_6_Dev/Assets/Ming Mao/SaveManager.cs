using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }
    private Vector2 lastCheckpointPosition;
    private bool hasCheckpoint = false;
    public GameObject player;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void UpdateCheckpoint(Vector2 newCheckpointPosition)
    {
        lastCheckpointPosition = newCheckpointPosition;
        hasCheckpoint = true;
    }

    public IEnumerator RespawnPlayer(GameObject player)
    {
        Debug.Log("RespawnPlayer started. Game paused.");
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1f);

        Time.timeScale = 1f;
        Debug.Log("Game resumed.");
        ShootingGel shootingGel = GameObject.Find("PlayerSquare").GetComponent<ShootingGel>();
        ProgressBar progressBar = GameObject.Find("PlayerSquare").GetComponent<ProgressBar>();
        progressBar.SaveBackProgressBar();
        shootingGel.shootNum = 1;
        if (shootingGel.shotObject != null)
        {
            shootingGel.shotObject.SetActive(false);
        }

        if (hasCheckpoint)
        {
            Debug.Log($"Moving player to checkpoint at {lastCheckpointPosition}.");
            player.transform.position = lastCheckpointPosition;
        }
        else
        {
            Debug.Log("No checkpoint found.");
        }
    }


    public bool HasCheckpoint()
    {
        return hasCheckpoint;
    }
}
