using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject prefabJugador;
    public Transform[] spawns;

    private void Start()
    {
        //CALCULAR UNA POSICION RANDOM ENTRE LAS 6 INICIALES
        PhotonNetwork.Instantiate(prefabJugador.name,spawns[0].position, Quaternion.identity);
    }
}
