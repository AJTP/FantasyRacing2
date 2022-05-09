using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField crearInput, unirInput;

    public void CrearSala() {
        PhotonNetwork.CreateRoom(crearInput.text);
    }

    public void EntrarSala() {
        PhotonNetwork.JoinRoom(unirInput.text);
    }

    public override void OnJoinedRoom() {
        PhotonNetwork.LoadLevel("Ovalo");
    }
}
