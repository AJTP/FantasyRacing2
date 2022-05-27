using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SueloFuego : Prop
{
    private void Start()
    {
        StartCoroutine(MuerteProp());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coche")) {
            other.GetComponent<Coche>().ActualizarHP(-10);
        }
    }
}
