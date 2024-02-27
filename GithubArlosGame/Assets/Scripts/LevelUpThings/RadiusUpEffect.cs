using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusUpEffect : LevelUpEffect
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
                float knifeScaleAmount = 0.3f;
                float swordScaleAmount = 0.6f;
                Player.WeaponParent.weapons[0].GetComponent<Weapon>().ChangeScale(knifeScaleAmount);
                Player.WeaponParent.weapons[1].GetComponent<Weapon>().ChangeScale(swordScaleAmount);
                Player.WeaponParent.weapons[0].radius = Player.WeaponParent.weapons[0].radius + 0.2f;
                Player.WeaponParent.weapons[1].radius = Player.WeaponParent.weapons[1].radius + 0.4f;
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
