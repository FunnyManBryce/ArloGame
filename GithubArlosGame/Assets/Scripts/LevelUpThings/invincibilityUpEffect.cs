using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincibilityUpEffect : LevelUpEffect
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
                playerController.health.invincibilityDuration = playerController.health.invincibilityDuration + 0.5f;
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
