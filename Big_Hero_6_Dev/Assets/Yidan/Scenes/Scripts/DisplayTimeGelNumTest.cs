using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayTimeGelNumTest : MonoBehaviour
{
    public TextMeshProUGUI gelNumberText;
    public GameObject timeGelYes;
    public GameObject timeGelNo;
    void Update()
    {
        
        Shadowing shadowing = GetComponent<Shadowing>();
        ShootingGelTest shootingGelTest = GetComponent<ShootingGelTest>();
        gelNumberText.text = "Your time gel number is " + shootingGelTest.shootNum;
        if (shootingGelTest.shootNum == 1)
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