using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaHerramientas : Prop
{
    private void Start()
    {
        transform.localRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y - 90, transform.rotation.eulerAngles.z);
        StartCoroutine(MuerteProp());
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Coche"))
            collision.transform.gameObject.GetComponent<Coche>().RecibirStun(3);
    }
}
