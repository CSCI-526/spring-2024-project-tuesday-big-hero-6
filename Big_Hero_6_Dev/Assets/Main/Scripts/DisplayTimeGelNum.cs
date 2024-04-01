using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayTimeGelNum : MonoBehaviour
{
    public TextMeshProUGUI gelNumberText;
    public GameObject timeGelYes;
    public GameObject timeGelNo;
    void Update()
    {
        
        Shadowing shadowing = GetComponent<Shadowing>();
        ShootingGel shootingGel = GetComponent<ShootingGel>();
        gelNumberText.text = "Your time gel number is " + shootingGel.shootNum;
        if (shootingGel.shootNum == 1)
        {
            timeGelYes.SetActive(true);
            timeGelNo.SetActive(false);
        }
        else
        {
            timeGelYes.SetActive(false);
            timeGelNo.SetActive(true);
        }

    }
}