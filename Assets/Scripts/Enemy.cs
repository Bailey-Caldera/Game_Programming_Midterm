using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHP = 3;
    private int currentHP;

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
        // Optional: add death animation, sound, particle effects
        Destroy(gameObject);
    }
}
