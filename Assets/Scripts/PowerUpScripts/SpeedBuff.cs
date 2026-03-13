using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "PowerUps/SpeedBuff")]
public class SpeedBuff : PowerUpEffect 

{
    public float amount;
    public float duration;
    public override void Apply(GameObject target)
    
    {
        PlayerMovement player = target.GetComponent<PlayerMovement>();
        if (player != null) {
        player.StartCoroutine(Speed(player));
        }
    }

    IEnumerator Speed(PlayerMovement player)
    {  
       
        player.moveSpeed += amount; 
        yield return new WaitForSeconds(duration);
        player.moveSpeed -= amount;
        yield return null;
    }

}