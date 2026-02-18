using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // First determine where in the game world that the player is pointing at with their mouse
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Then if the players mouse clicked an actual in-game collider...
        if (Physics.Raycast(ray, out hit))
        {
            // calculate the direction between the player and the clicked world point
            Vector3 direction = hit.point - transform.position;
            direction.y = 0f; // flatten that direction (so that its horizonal - it doesnt shoot angled into the ceiling or floor)
            direction.Normalize(); // guarantee the vector is the same size no matter the distance between player & click location

            transform.forward = direction; // make the player face the direction you're shooting

            // instantiate the projectile in the direction calculated
            GameObject projectile = Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(direction));


            // Get the player and the projectiles colliders and make them ignore hitting each other
            Collider playerCollider = GetComponent<CharacterController>();
            Collider projectileCollider = projectile.GetComponent<Collider>();
            Physics.IgnoreCollision(playerCollider, projectileCollider);


        }
    }
}
