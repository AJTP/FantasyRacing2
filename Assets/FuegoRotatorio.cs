using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuegoRotatorio : Prop
{
    private void Start()
    {
        
        StartCoroutine(MuerteProp());
    }
    void Update()
    {
        transform.Rotate(new Vector3(0,90*Time.deltaTime,0));
    }

    public void SetParent(Transform t)
    {
        this.transform.SetParent(t.transform);
        this.transform.position += new Vector3(0, 2, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coche"))
        {
            //#SONIDO QUEMAR
            other.GetComponent<Coche>().ActualizarHP(-20);
        }
    }
}
