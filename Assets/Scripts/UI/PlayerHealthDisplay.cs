using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealthDisplay : MonoBehaviour
{
    public TMP_Text playerHealthText;

    public Health playerHealth;

    private void Update()
    {
        if (playerHealth != null)
        {
            UpdateHealthText();
        }
    }
    void UpdateHealthText()
    {
        playerHealthText.text = "Health:" + playerHealth.currentHealth;
    }
}
