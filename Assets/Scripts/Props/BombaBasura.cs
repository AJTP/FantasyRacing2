using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaBasura : Prop
{
    public GameObject explosion;
    void Start()
    {
        StartCoroutine(Explotar());    
    }

    public IEnumerator Explotar() {
        yield return new WaitForSeconds(4);
        this.GetComponent<AudioSource>().PlayOneShot(sonido);
        GameObject.Instantiate(explosion,transform);
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
        Destroy(this);
    }
}
