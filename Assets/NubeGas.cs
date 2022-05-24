using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NubeGas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coche")) {
            StartCoroutine(other.GetComponent<Coche>().AplicarCeguera());       
        }
    }
}
