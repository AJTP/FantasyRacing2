using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    GameObject miJugador;
    //SPAWNS
    private List<Transform> spawns = new List<Transform>();
    public GameObject prefabJugador;

    GameObject puntosControl;
    GameObject meta;
    List<GameObject> puntos = new List<GameObject>();
    //Dictionary<int, Jugador> jugadores = new Dictionary<int, Jugador>();
    void Start()
    {
        //CARGAR SPAWNS
        CargarSpawns();
        Transform randomSpawn = GetRandomSpawn();
        miJugador = PhotonNetwork.Instantiate(prefabJugador.name, randomSpawn.position, randomSpawn.rotation);
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


        //PUNTOS DE CONTROL CARGADOS
        puntosControl = GameObject.Find("PuntosControl");
        for(int i=0;i<puntosControl.transform.childCount;i++){
            puntos.Add(puntosControl.transform.GetChild(i).gameObject);
        }

        //META CARGADA
        meta = GameObject.Find("Meta");
        
        //CARGAR JUGADORES

    }

    public Transform GetRandomSpawn() {
        System.Random rnd = new System.Random();
        Debug.Log(spawns.Count);
        int indice = rnd.Next(0, spawns.Count - 1);
        Debug.Log(indice);
        Transform t = spawns[indice];
        Debug.Log(t.name);
        return t;
    }

    public void CargarSpawns() {
        GameObject padre = GameObject.Find("Spawns");
        for (int i = 0; i < padre.transform.childCount; i++)
        {
            spawns.Add(padre.transform.GetChild(i));
        }
    }
}