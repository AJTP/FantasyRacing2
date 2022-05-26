using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBomba : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Muere());
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coche"))
        {
            other.GetComponent<Coche>().RecibirResbalar(10000,10000);
        }
    }

    public IEnumerator Muere() {
        yield return new WaitForSeconds(1);
    }
}
