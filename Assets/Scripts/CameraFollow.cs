using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // your player
    public Vector3 offset = new Vector3(0, 25, -5);

    void LateUpdate()
    {
        transform.position = target.position + offset;
        transform.LookAt(target.position);
    }
}

