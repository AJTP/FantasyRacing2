using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuego : Prop
{
    private void Start()
    {
        StartCoroutine(MuerteProp());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coche"))
        {
            //#SONIDO QUEMAR
            other.GetComponent<Coche>().ActualizarHP(-5);
        }
    }
}
