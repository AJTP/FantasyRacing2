using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NubeGas : Prop
{
    private void Start()
    {
        StartCoroutine(MuerteProp());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coche")) {
            //#SONIDO GAS
            StartCoroutine(other.GetComponent<Coche>().AplicarCeguera());       
        }
    }
}
