using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayIntervalsTest : MonoBehaviour
{
    public TextMeshProUGUI intervalText; 

    void Update()
    {
        
        Shadowing shadowing = GetComponent<Shadowing>();
        if (shadowing.gelFlag == 0)
        {
            intervalText.text = "Your shadow is" + " 0.5s away";
        }
        else
        {
            intervalText.text = "Your shadow is" + " 1s away";
        }

    }
}
