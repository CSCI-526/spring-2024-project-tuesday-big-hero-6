using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonControl : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Basic_Level");
    }


    public void Tutorial()
    {
        SceneManager.LoadScene("Tutorial1");
    }
}
