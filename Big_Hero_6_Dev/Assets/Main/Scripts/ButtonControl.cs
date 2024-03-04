using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public void MainMenu()
    {
        Global.redKey = false;
        Global.yellowKey = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }

    public void Level1()
    {
        Global.redKey = false;
        Global.yellowKey = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 1");
    }

    public void Level2()
    {
        Global.redKey = false;
        Global.yellowKey = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Level 2");
    }

    public void Tutorial1()
    {
        Global.redKey = false;
        Global.yellowKey = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Tutorial1");
    }


    public void Tutorial2()
    {
        Global.redKey = false;
        Global.yellowKey = false;
        Time.timeScale = 1;
        SceneManager.LoadScene("Tutorial2");
    }
}
