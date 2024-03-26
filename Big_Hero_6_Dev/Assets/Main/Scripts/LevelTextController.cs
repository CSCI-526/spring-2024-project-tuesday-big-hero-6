using UnityEngine;

public class LevelTextController : MonoBehaviour
{
    public GameObject[] levelTexts; // Level文本的GameObject数组
    public GameObject T2;

    void Update()

        
    {
        if (Global.showTutorial2 == false)
        {
            T2.SetActive(false);
        }
        else
        {
            T2.SetActive(true);
        }

        if (Global.tutorial1 == false || Global.tutorial2 == false)
        {
            //if (levelTexts.Length >= 2)
            //{
                levelTexts[0].SetActive(false);
                levelTexts[1].SetActive(false);
                levelTexts[2].SetActive(false);
                levelTexts[3].SetActive(false);
                levelTexts[4].SetActive(false);
                levelTexts[5].SetActive(false);
            //}
        }
        else
        {
            if (levelTexts.Length >= 2)
            {
                levelTexts[0].SetActive(true);
                levelTexts[1].SetActive(true);
                levelTexts[2].SetActive(true);
                levelTexts[3].SetActive(true);
                levelTexts[4].SetActive(true);
                levelTexts[5].SetActive(true);
            }
        }

    }
}
