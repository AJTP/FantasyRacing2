using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Desfibrilador : MonoBehaviour
{

    void Start()
    {

        StartCoroutine(PegarCalambre());
    }

    public void SetParent(Transform c) {
        this.transform.SetParent(c.transform);
    }

    public IEnumerator PegarCalambre()
    {
        //#SONIDO DESFIBRILADOR
        GameObject[] coches = GameObject.FindGameObjectsWithTag("Coche");
        for (int i = 0; i < coches.Length; i++)
        {
            SetParent(coches[i].GetComponent<Coche>().puntoPrefabs.transform);
            this.transform.position += new Vector3(0, 2, 0);
            transform.localRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 90, transform.rotation.eulerAngles.z);
        }
        yield return new WaitForSeconds(1);
        //#SONIDO CALAMBRE

        for (int i = 0; i < coches.Length; i++)
        {
            coches[i].GetComponent<Coche>().RecibirStun(3);
        }
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
        Destroy(this);
    }

}
