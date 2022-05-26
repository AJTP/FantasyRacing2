using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombaBasura : Prop
{
    void Start()
    {
        StartCoroutine(Explotar());    
    }

    public IEnumerator Explotar() {
        yield return new WaitForSeconds(4);
        //GameObject.Instantiate();
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
        Destroy(this);
    }
}
