using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public void MainMenu()
    {
        ResetGame();
        SceneManager.LoadScene("Main Menu");
    }

    public void Level1()
    {
        ResetGame();
        SceneManager.LoadScene("Level 1");
    }

    public void Level2()
    {
        ResetGame();
        SceneManager.LoadScene("Level 2");
    }

    public void Level3()
    {
        ResetGame();
        SceneManager.LoadScene("Level 3");
    }

    public void Level4()
    {
        ResetGame();
        SceneManager.LoadScene("Level 4");
    }

    public void Level5()
    {
        ResetGame();
        SceneManager.LoadScene("Level 5");
    }

    public void Level6()
    {
        ResetGame();
        SceneManager.LoadScene("Level 6");
    }



    public void Tutorial1()
    {
        ResetGame();
        SceneManager.LoadScene("Tutorial1");
    }

    public void Tutorial2()
    {
        ResetGame();
        SceneManager.LoadScene("Tutorial2");
    }

    public void Tutorial3()
    {
        ResetGame();
        SceneManager.LoadScene("Tutorial3");
    }

    public void NextLevel()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        switch (currentScene)
        {
            case "Main Menu":
                Tutorial1();
                break;
            case "Tutorial1":
                Tutorial2();
                break;
            case "Tutorial2":
                Level1();
                break;
            case "Level 1":
                Tutorial3();
                break;
            case "Tutorial3":
                Level2();
                break;
            case "Level 2":
                Level3();
                break;
            case "Level 3":
                MainMenu();
                break;
            default:
                Debug.Log("Unrecognized scene or no next scene available.");
                break;
        }
    }

    private void ResetGame()
    {
        Global.redKey = false;
        Global.yellowKey = false;
        Time.timeScale = 1;
    }
}
