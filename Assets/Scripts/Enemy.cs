using System;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

    public List<PowerUpDrop> drops;

    public static event Action onEnemyDeath;

    void Start()
    {
        currentHP = maxHP;
    }

    // Call this to deal damage
    public void TakeDamage(int amount)
    {
        currentHP -= amount;

        if (currentHP <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        DropPowerUp();
        onEnemyDeath?.Invoke();
        Destroy(gameObject);
    }

    void DropPowerUp()
    {
        foreach (PowerUpDrop drop in drops)
        {
            float dropchance = UnityEngine.Random.Range(0f, 100f);

            if (dropchance <= drop.dropChance)
            {
                Instantiate(drop.PowerUp, transform.position, Quaternion.identity);
                break; 
        }
     }
    }

}
