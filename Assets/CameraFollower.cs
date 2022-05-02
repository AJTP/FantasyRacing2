using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform objetivo;

    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private void LateUpdate()
    {
        transform.position = objetivo.position + offset;
    }
}
