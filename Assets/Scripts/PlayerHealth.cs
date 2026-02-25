using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 5;
    private int currentHP;

    void Start()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        Debug.Log("Player hit! HP: " + currentHP);

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player dead!");
        // Add respawn, scene reload, or death animation here...
        
        gameObject.SetActive(false);
    }
}

