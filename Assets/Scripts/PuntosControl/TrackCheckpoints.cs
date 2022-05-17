using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackCheckpoints : MonoBehaviour
{
    [SerializeField] private List<Transform> transformCochesLista;
    [SerializeField] private List<Coche> cochesLista;
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
       
        int siguientePunto = siguientePuntoLista[transformCochesLista.IndexOf(carT)];
        if (puntosLista.IndexOf(puntoControl) == siguientePunto)
        {

            //ORDEN CORRECTO
            siguientePuntoLista[transformCochesLista.IndexOf(carT)] = (siguientePunto + 1) % puntosLista.Count;
            cochesLista[transformCochesLista.IndexOf(carT)].ActualizaControl(siguientePunto);
            Debug.Log(carT.transform.name + "CORRECTO" + siguientePunto);
            if (siguientePunto == 0) {
                cochesLista[transformCochesLista.IndexOf(carT)].SumaVuelta();
            }
        }
        else {
            //Punto de control incorrecto
        }
    }

    public void AddCocheTransform(Transform coche) {
        transformCochesLista.Add(coche);
        siguientePuntoLista.Add(0);
        Debug.Log("COCHE ADDED" + coche.transform.name);
    }

    public void AddCoche(Coche coche)
    {
        cochesLista.Add(coche);
        Debug.Log("COCHE ADDED" + coche.transform.name);
    }
}
