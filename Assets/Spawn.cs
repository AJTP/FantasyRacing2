using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class Spawn : MonoBehaviour
{
    public GameObject prefab;
    public Transform punto;
    void Start()
    {
        PhotonNetwork.Instantiate(prefab.name, punto.position, Quaternion.identity);
    }

}
