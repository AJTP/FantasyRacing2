using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaldosaAceleradora : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coche")) {
            other.GetComponent<Coche>().RecibirBoost(8000);
        }
    }
}
