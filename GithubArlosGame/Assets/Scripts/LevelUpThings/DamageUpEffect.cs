using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageUpEffect : LevelUpEffect
{
    public player Player;

    public override void ApplyEffect()
    {
        GameObject player = GameObject.FindWithTag("Player");


        if (player != null)
        {
            //refrence the player not player controller
            Player = player.GetComponent<player>();

            if (Player != null)
            {
                Player.WeaponParent.weapons[0].damage = Player.WeaponParent.weapons[0].damage + 2;
                Player.WeaponParent.weapons[1].damage = Player.WeaponParent.weapons[1].damage + 4;
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
