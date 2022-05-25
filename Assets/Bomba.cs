using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : Prop
{
    public GameObject prefab;
    public Rigidbody rb;
    public Vector3 direccion = new Vector3(0, 0, 0);
    int i = 0;
    private void Start()
    {
        StartCoroutine(MuerteProp());
    }

    private void FixedUpdate()
    {
        if (i == 0)
        {
            rb.AddForce(direccion + new Vector3(0, 100, 0), ForceMode.Impulse);
            i++;
        }
        
    }

    public void SetVector(Vector3 v)
    {
        this.direccion = v;
    }

    private void OnCollisionEnter(Collision collision)
    {
        //SONIDO EXPLOSION
        PhotonNetwork.Instantiate(prefab.name, transform.position+new Vector3(0,1.5f,0), Quaternion.identity);
        Destroy(this.gameObject);
        Destroy(this);
    }
}
