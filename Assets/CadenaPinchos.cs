using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CadenaPinchos : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coche"))
        {
            //#SONIDO RALENTIZAR
            other.GetComponent<Coche>().RecibirRalentizar(3);
        }
    }
}
