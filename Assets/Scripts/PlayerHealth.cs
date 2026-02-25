using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHP = 5;
    private int currentHP;

    public static event Action onPlayerDeath;
    public static event Action<int> onPlayerDamage;

    void Start()
    {
        currentHP = maxHP;

        onPlayerDeath += Die;
    }

    public void TakeDamage(int amount)
    {
        currentHP -= amount;
        Debug.Log("Player hit! HP: " + currentHP);
        onPlayerDamage?.Invoke(currentHP);

        if (currentHP <= 0)
        {
            onPlayerDeath?.Invoke();
        }
    }

    void Die()
    {
        Debug.Log("Player dead!");
        // Add respawn, scene reload, or death animation here...
        
        gameObject.SetActive(false);
    }
}

