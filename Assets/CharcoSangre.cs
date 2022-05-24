using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharcoSangre : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coche"))
        {
            //#SONIDO RESBALAR
            other.GetComponent<Coche>().RecibirResbalar();
        }
    }
}
