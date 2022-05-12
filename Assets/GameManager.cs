using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject puntosControl;
    GameObject meta;
    List<GameObject> puntos = new List<GameObject>();
    int contadorpuntos = 0;
    //Dictionary<int, Jugador> jugadores = new Dictionary<int, Jugador>();
    void Start()
    {
        //PUNTOS DE CONTROL CARGADOS
        puntosControl = GameObject.Find("PuntosControl");
        for(int i=0;i<puntosControl.transform.childCount;i++){
            puntos.Add(puntosControl.transform.GetChild(i).gameObject);
        }

        //META CARGADA
        meta = GameObject.Find("Meta");
        
        //CARGAR JUGADORES

    }
}