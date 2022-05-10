using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject puntosControl;
    List<GameObject> puntos = new List<GameObject>();
    void Start()
    {
        //PUNTOS DE CONTROL CARGADOS
        puntosControl = GameObject.Find("PuntosControl");
        for(int i=0;i<puntosControl.transform.childCount;i++){
            puntos.Add(puntosControl.transform.GetChild(i).gameObject);
        }

        
    }
}