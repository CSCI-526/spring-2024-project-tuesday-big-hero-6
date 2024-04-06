using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menu;

    void Start()
    {
        menu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            menu.SetActive(!menu.activeSelf);
            PauseGame(menu.activeSelf);
        }
    }

    void PauseGame(bool isPaused)
    {
        if (isPaused)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void ResumeGame()
    {
        menu.SetActive(false);
        PauseGame(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void LoadMainMenu()
    {

        SceneManager.LoadScene("MainMenu");
    }

}
