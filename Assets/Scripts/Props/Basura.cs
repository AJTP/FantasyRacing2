using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basura : Prop
{
    private void Start()
    {
        StartCoroutine(MuerteProp());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coche"))
        {
            this.GetComponent<AudioSource>().PlayOneShot(sonido);
            other.GetComponent<Coche>().RecibirRalentizar(3);
            other.GetComponent<Coche>().ActualizarHP(-10);
            
        }
    }
}
