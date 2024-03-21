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
        ShootingGel shootingGel = GetComponent<ShootingGel>();
        gelNumberText.text = "Your time gel number is " + shootingGel.shootNum;

    }
}