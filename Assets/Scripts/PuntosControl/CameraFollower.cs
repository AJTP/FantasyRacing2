using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    private Transform objetivo;
    private Transform puntoCamara;

    public float velocidadSuavizada = 0.125f;

    public Transform Objetivo { get => objetivo; set => objetivo = value; }
    public Transform PuntoCamara { get => puntoCamara; set => puntoCamara = value; }

    private void LateUpdate()
    {
        puntoCamara.rotation = new Quaternion(-objetivo.rotation.eulerAngles.x,puntoCamara.rotation.eulerAngles.y,-objetivo.rotation.eulerAngles.z,0f);
        transform.position = new Vector3(puntoCamara.transform.position.x, puntoCamara.transform.position.y, puntoCamara.transform.position.z);
        transform.LookAt(objetivo);
    }
}
