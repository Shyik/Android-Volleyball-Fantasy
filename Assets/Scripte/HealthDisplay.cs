using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    public PlayerController playerController;
    public Text healthAmount;
    
    
    void Update()
    {
        healthAmount.text = "HP: " + playerController.currentHealth;
    }
}
