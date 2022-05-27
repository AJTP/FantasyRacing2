using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaldosaAceleradora : MonoBehaviour
{
    public AudioClip sonido;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coche")) {
            this.GetComponent<AudioSource>().PlayOneShot(sonido);
            other.GetComponent<Coche>().RecibirBoost(8000);
        }
    }
}
