using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcoSangre : Prop
{
    private void Start()
    {
        StartCoroutine(MuerteProp());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coche"))
        {
            //#SONIDO RESBALAR
            this.GetComponent<AudioSource>().PlayOneShot(sonido);
            other.GetComponent<Coche>().RecibirResbalar();
        }
    }
}
