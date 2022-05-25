using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionCaidaEscenario : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coche"))
        {
            Debug.Log("UN COCHE SE HA CAIDO");
            other.GetComponent<Coche>().Respawn();
        }
    }
}
