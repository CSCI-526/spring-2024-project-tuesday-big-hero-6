using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DisplayTimeGelNum : MonoBehaviour
{
    public TextMeshProUGUI gelNumberText; 

    void Update()
    {
        
        Shadowing shadowing = GetComponent<Shadowing>();
        ShootingGelTest shootingGelTest = GetComponent<ShootingGelTest>();
        gelNumberText.text = "Your time gel number is " + shootingGelTest.shootNum;

    }
}