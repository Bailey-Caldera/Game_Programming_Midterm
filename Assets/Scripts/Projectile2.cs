using UnityEngine;

public class Projectile2 : MonoBehaviour
{
    public float speed = 5f;
    public float lifetime = 3f;
    public int damage = 3;

    void Start()
    {
        Destroy(gameObject, lifetime); // auto-destroy after some time
    }

    void Update()
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check for enemy
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
            return;
        }

        // Optional: destroy on walls or other obstacles
        if (other.gameObject.layer == LayerMask.NameToLayer("Obstacle"))
        {
            Destroy(gameObject);
        }
    }
}



