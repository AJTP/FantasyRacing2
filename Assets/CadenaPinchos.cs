using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CadenaPinchos : Prop
{
    private void Start()
    {
        StartCoroutine(MuerteProp());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coche"))
        {
            //#SONIDO RALENTIZAR
            other.GetComponent<Coche>().RecibirRalentizar(3);
        }
    }
}
