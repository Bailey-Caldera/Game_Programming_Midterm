using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    private CharacterController charController;

    public float moveSpeed = 20f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        charController = GetComponent<CharacterController>();
    }

    
    void Update()
    {
        // Get input
        float moveX = Input.GetAxisRaw("Horizontal"); // A/D
        float moveZ = Input.GetAxisRaw("Vertical");   // W/S

        // Movement vector relative to world axes
        Vector3 move = new Vector3(moveX, 0f, moveZ).normalized;

        // Move the character
        charController.Move(move * moveSpeed * Time.deltaTime);
    }

}
