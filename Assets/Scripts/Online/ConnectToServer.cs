using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    void Start()
    {
        //LANZA LA ORDEN PARA CONECTARSE AL SERVIDOR
        PhotonNetwork.ConnectUsingSettings();
    }
    public override void OnConnectedToMaster() {
        //CUANDO SE CONECTA SATISFACTORIAMENTE AL SERVIDOR
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby() {
        //CUANDO SE CONECTA AL LOBBY
        SceneManager.LoadScene("Rooms(3)");
    }
}
