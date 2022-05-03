using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform objetivo;
    public Transform puntoCamara;

    public float velocidadSuavizada = 0.125f;
  
    private void FixedUpdate()
    {
        transform.position = new Vector3(puntoCamara.transform.position.x, puntoCamara.transform.position.y+1, puntoCamara.transform.position.z);
        transform.rotation = new Quaternion(0f, puntoCamara.rotation.eulerAngles.y,0f, 0f);
        //transform.LookAt(objetivo);
    }
}
