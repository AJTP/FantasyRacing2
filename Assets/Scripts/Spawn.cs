using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Spawn : MonoBehaviour
{
    private GameObject miJugador;

    GameObject puntosControl;
    GameObject meta;
    List<GameObject> puntos = new List<GameObject>();

    void Start()
    {
        //CARGAR SPAWNS
        GameManager.Instancia.CargarSpawns();
        //PUNTOS DE CONTROL CARGADOS
        puntosControl = GameObject.Find("PuntosControl");
        for (int i = 0; i < puntosControl.transform.childCount; i++)
        {
            puntos.Add(puntosControl.transform.GetChild(i).gameObject);
        }

        //META CARGADA
        meta = GameObject.Find("Meta");

    }

    public void SpawnJugador(GameObject prefab) {
        Transform randomSpawn = GameManager.Instancia.GetRandomSpawn();
        miJugador = PhotonNetwork.Instantiate(prefab.name, randomSpawn.position, randomSpawn.rotation);
        GameObject camara = GameObject.FindWithTag("MainCamera");
        if (camara != null)
        {
            camara.GetComponent<CameraFollower>().Objetivo = miJugador.transform;
            camara.GetComponent<CameraFollower>().PuntoCamara = miJugador.GetComponent<ControlCamaras>().puntoNormal;

        }
        GameObject camaraMinimapa = GameObject.FindWithTag("MiniCamera");
        camaraMinimapa.transform.position = miJugador.GetComponent<ControlCamaras>().puntoMinimapa.transform.position;
        GameObject camaraRetro = GameObject.FindWithTag("RetroCamera");
        camaraRetro.GetComponent<CameraFollower>().Objetivo = miJugador.transform;
        camaraRetro.GetComponent<CameraFollower>().PuntoCamara = miJugador.GetComponent<ControlCamaras>().puntoRetrovisor;
        camaraRetro.SetActive(false);
    }
    

}
