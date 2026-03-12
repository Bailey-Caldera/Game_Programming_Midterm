using UnityEngine;

public class ApplyPowerUp : MonoBehaviour
{
    public PowerUpEffect PowerUpEffect;
    private void OnTriggerEnter(Collider collision) {
    if(collision.CompareTag("Player")) {
        
        Destroy(gameObject);
        PowerUpEffect.Apply(collision.gameObject);
    
     }
    }
}
