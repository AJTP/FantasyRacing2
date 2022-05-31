using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class TroncoRodante : Prop
{
    public Rigidbody rb;
    public Vector3 direccion = new Vector3(0, 0, 0);
    private int i = 0;
    private void Start()
    {
        StartCoroutine(MuerteProp());
        transform.Rotate(new Vector3(0,0,90));
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(180,0, 0) * Time.deltaTime);
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
        if (other.CompareTag("Coche"))
        {
            this.GetComponent<AudioSource>().PlayOneShot(sonido);
            other.GetComponent<Coche>().RecibirStun(2);
        }
        PhotonNetwork.Destroy(this.gameObject);
    }
}