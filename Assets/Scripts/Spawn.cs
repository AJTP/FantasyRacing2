using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Spawn : MonoBehaviour
{

    public GameObject[] prefabsJugadores;
    public Transform[] puntosSpawn;







    private GameObject miJugador;
    GameObject puntosControl;
    GameObject meta;
    List<GameObject> puntos = new List<GameObject>();

    void Start()
    {
        int numeroRandom = Random.Range(0, puntosSpawn.Length);
        Transform puntoSpawn = puntosSpawn[numeroRandom];
        GameObject jugadorAlSpawn = prefabsJugadores[(int)PhotonNetwork.LocalPlayer.CustomProperties["avatarJugador"]];
        miJugador = PhotonNetwork.Instantiate(jugadorAlSpawn.name, puntoSpawn.position, puntoSpawn.rotation);
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
        for (int i = 0; i < puntosControl.transform.childCount; i++)
        {
            puntos.Add(puntosControl.transform.GetChild(i).gameObject);
        }
    }

    public void SpawnJugador(GameObject prefab) {
        /*if (!GameObject.Find("RANKING(Clone)"))
        {
            Debug.Log("NO EXISTE, LO CREO");
            PhotonNetwork.Instantiate("RANKING", Vector3.zero, Quaternion.identity);
        }
        else {
            Debug.Log("YA EXISTE, ME QUEDO QUIETO");
        }*/
        //Transform randomSpawn = GameManager.Instancia.GetRandomSpawn();
        //miJugador = PhotonNetwork.Instantiate(prefab.name, randomSpawn.position, randomSpawn.rotation);
        //GameObject camara = GameObject.FindWithTag("MainCamera");
        //if (camara != null)
        //{
        //    camara.GetComponent<CameraFollower>().Objetivo = miJugador.transform;
        //    camara.GetComponent<CameraFollower>().PuntoCamara = miJugador.GetComponent<ControlCamaras>().puntoNormal;

        //}
        //GameObject camaraMinimapa = GameObject.FindWithTag("MiniCamera");
        //camaraMinimapa.transform.position = miJugador.GetComponent<ControlCamaras>().puntoMinimapa.transform.position;
        //GameObject camaraRetro = GameObject.FindWithTag("RetroCamera");
        //camaraRetro.GetComponent<CameraFollower>().Objetivo = miJugador.transform;
        //camaraRetro.GetComponent<CameraFollower>().PuntoCamara = miJugador.GetComponent<ControlCamaras>().puntoRetrovisor;
        //camaraRetro.SetActive(false);
    }
    

}
