using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform objetivo;

    public float velocidadSuavizada = 0.125f;
    public Vector3 offset;

    private void FixedUpdate()
    {
        Vector3 posicionDeseada = objetivo.position + offset;
        Vector3 posicionSuavizada = Vector3.Lerp(transform.position, posicionDeseada, velocidadSuavizada);
        transform.position = posicionSuavizada;
        transform.rotation = objetivo.rotation;
        transform.LookAt(objetivo);
    }
}
