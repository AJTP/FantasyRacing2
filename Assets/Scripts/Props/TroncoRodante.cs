using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroncoRodante : Prop
{
    public GameObject prefab;
    public Rigidbody rb;
    public Vector3 direccion = new Vector3(0, 0, 0);
    private void Start()
    {
        StartCoroutine(MuerteProp());
    }

    private void FixedUpdate()
    {
        transform.Translate(direccion*Time.deltaTime);
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

    }
}