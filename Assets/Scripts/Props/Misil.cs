using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : Prop
{
    public Vector3 direccion = new Vector3(0, 0, 0);
    public Rigidbody rb;
    private int i = 0;
    private void Start()
    {
        StartCoroutine(MuerteProp());
    }

    private void FixedUpdate()
    {
        if (i == 0)
        {
            rb.AddForce(direccion, ForceMode.Impulse);
            i++;
        }   
    }

    public void SetVector(Vector3 v)
    {
        this.direccion = v;
    }

    private void OnTriggerEnter(Collider other)
    {
        //LE DIGO AL OTRO QUE PIERDA VIDA
        if (other.CompareTag("Coche")) {
            this.GetComponent<AudioSource>().PlayOneShot(sonido);
            other.GetComponent<Coche>().ActualizarHP(-5);
        }
        //DESAPARECE LA BALA
        PhotonNetwork.Destroy(this.gameObject);
        
    }
}
