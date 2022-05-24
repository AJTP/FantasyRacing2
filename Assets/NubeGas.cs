using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NubeGas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coche")) {
            Debug.Log("HA ENTRADO UN COCHE");
            StartCoroutine(other.GetComponent<Coche>().AplicarCeguera());       
        }
    }
}
