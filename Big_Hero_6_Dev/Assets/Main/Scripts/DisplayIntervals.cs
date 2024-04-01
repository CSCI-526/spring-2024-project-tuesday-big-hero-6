using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayIntervals : MonoBehaviour
{
    public TextMeshProUGUI intervalText;
    public GameObject intervalGel;
    public GameObject intervalNor;
    void Update()
    {
        
        Shadowing shadowing = GetComponent<Shadowing>();
        if (shadowing.gelFlag == 0)
        {
            intervalText.text = "Your shadow is" + " 0.5s away";
            intervalGel.SetActive(false);
            intervalNor.SetActive(true);
            
        }
        else
        {
            intervalText.text = "Your shadow is" + " 1s away";
            intervalGel.SetActive(true);
            intervalNor.SetActive(false);
        }

    }
}