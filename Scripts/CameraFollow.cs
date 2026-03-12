using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // your player
    public Vector3 offset = new Vector3(0, 25, -5);
    
    // Area where camera will be bound
    public float minX, maxX, minZ, maxZ;

    void LateUpdate()
    {
        // Set the inital camera position
        Vector3 cameraPos = target.position + offset;

        // Camera can't look out of bound and can only look within bound
        cameraPos.x = Mathf.Clamp(cameraPos.x, minX, maxX);
        cameraPos.z = Mathf.Clamp(cameraPos.z, minZ, maxZ);

        transform.position = cameraPos;
    }
}

