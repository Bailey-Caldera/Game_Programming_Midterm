using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour
{
    public float moveSpeed = 12f;
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float attackRange = 15f;
    public float attackCooldown = 3f;

    private Transform player;
    private Renderer rend;
    private Color originalColor;
    private bool canAttack = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rend = GetComponent<Renderer>();
        originalColor = rend.material.color;
    }

    void Update()
    {
        if (player == null) return;

        // Move toward player
        Vector3 direction = player.position - transform.position;
        direction.y = 0f; // keep flat
        if (direction.magnitude > attackRange)
        {
            transform.position += direction.normalized * moveSpeed * Time.deltaTime;
            transform.forward = direction.normalized;
        }
        else if (canAttack)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        canAttack = false;

        // Flash red twice
        for (int i = 0; i < 2; i++)
        {
            rend.material.color = Color.red;
            yield return new WaitForSeconds(0.15f);
            rend.material.color = originalColor;
            yield return new WaitForSeconds(0.15f);
        }

        // Shoot projectile at player
        Vector3 direction = player.position - firePoint.position;
        direction.y = 0f;
        direction.Normalize();

        Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));

        // Wait cooldown
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}

