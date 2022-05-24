using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoRodante : MonoBehaviour
{
    public Rigidbody rb;
    public Vector3 direccion = new Vector3(0,0,0);

    void Update()
    {
        rb.AddForce(direccion, ForceMode.Acceleration);
    }

    public void SetVector(Vector3 v) {
        this.direccion = v;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //EL OTRO JUGADOR PIERDE VIDA Y SE STUNEA
    }
}