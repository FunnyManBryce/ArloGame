using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxHealEffect : LevelUpEffect
{
    public playerController playerController;

    public override void ApplyEffect()
    {
        GameObject player = GameObject.FindWithTag("Player");


        if (player != null)
        {
            playerController = player.GetComponent<playerController>();

            if (playerController != null)
            {
                playerController.health.maxHealth = playerController.health.maxHealth + 80;
                playerController.health.currentHealth = playerController.health.currentHealth + 80;
                playerController.OnTakeDamage();
            }
            else
            {
                Debug.LogWarning("PlayerController killed its self");
            }
        }
        else
        {
            Debug.LogWarning("Player killed its self");
        }
    }
}
