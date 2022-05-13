using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    [SerializeField] private List<Transform> cochesLista;
    private List<PuntoControl> puntosLista;
    private List<int> siguientePuntoLista;
    private void Awake()
    {
       Transform puntosControlTransform = transform.Find("PuntosControl");
        puntosLista = new List<PuntoControl>();
        foreach (Transform puntoControl in puntosControlTransform) {
            PuntoControl punto = puntoControl.GetComponent<PuntoControl>();
            punto.SetTrack(this);
            puntosLista.Add(punto);
        }
        siguientePuntoLista = new List<int>();
    }

    public void CochePasaPuntoControl(PuntoControl puntoControl,Transform carT) {
       
        int siguientePunto = siguientePuntoLista[cochesLista.IndexOf(carT)];
        if (puntosLista.IndexOf(puntoControl) == siguientePunto)
        {

            //ORDEN CORRECTO
            siguientePuntoLista[cochesLista.IndexOf(carT)] = (siguientePunto + 1) % puntosLista.Count;
            Debug.Log(carT.transform.name + "CORRECTO");
            if (siguientePunto == 0) {
                carT.gameObject.GetComponent<Coche>().SumaVuelta();
            }

        }
        else {
            //Punto de control incorrecto
        }
    }

    public void AddCocheTransform(Transform coche) {
        cochesLista.Add(coche);
        siguientePuntoLista.Add(0);
        Debug.Log("COCHE ADDED" + coche.transform.name);
    }
}
