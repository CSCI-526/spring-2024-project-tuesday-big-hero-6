using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject menu;
    public GameObject tabMenu;
    public GameObject instructMenu;

    void Start()
    {
        menu.SetActive(false);
        tabMenu.SetActive(true);
        instructMenu.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (menu.activeSelf && instructMenu.activeSelf)
            {
                ShowTabMenu();
            }
            else
            {
                menu.SetActive(!menu.activeSelf);
                ShowTabMenu();
            }
            PauseGame(menu.activeSelf);
        }
    }

    private void ShowTabMenu()
    {
        tabMenu.SetActive(true);
        instructMenu.SetActive(false);
    }

    public void ShowInstructMenu()
    {
        tabMenu.SetActive(false);
        instructMenu.SetActive(true);
    }

    public void BackToTabMenu()
    {
        ShowTabMenu();
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
