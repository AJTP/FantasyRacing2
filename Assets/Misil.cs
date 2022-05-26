using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : Prop
{
    public Vector3 direccion = new Vector3(0, 0, 0);
    private void Start()
    {
        StartCoroutine(MuerteProp());
    }

    private void FixedUpdate()
    {
        transform.Translate(direccion * Time.deltaTime);
    }

    public void SetVector(Vector3 v)
    {
        this.direccion = v;
    }

    private void OnTriggerEnter(Collider other)
    {
        //LE DIGO AL OTRO QUE PIERDA VIDA
        if (other.CompareTag("Coche")) {
            other.GetComponent<Coche>().ActualizarHP(-5);
        }
        //DESAPARECE LA BALA
        Destroy(this.gameObject);
        Destroy(this);
    }
}
