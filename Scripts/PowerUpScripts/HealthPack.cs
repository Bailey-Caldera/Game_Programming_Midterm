using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PowerUps/HealthPack")]
public class HealthPack : PowerUpEffect

{
    public int amount;
    public override void Apply(GameObject target)
    {

        PlayerHealth player = target.GetComponent<PlayerHealth>();
        if (player != null) {
            player.ApplyHealthPowerUp(amount);
        }
    }
}
