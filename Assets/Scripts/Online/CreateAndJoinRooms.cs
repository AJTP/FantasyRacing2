using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
using System;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    public InputField crearInput;
    public GameObject panelLobby, panelSala;
    public Text nombreSala;
    public SalaItem salaItemPrefab;
    List<SalaItem> salaItemLista = new List<SalaItem>();
    public Transform objetoContenido;

    public float tiempoEntreUpdates;
    float siguienteUpdate;

    private void Start()
    {
        PhotonNetwork.JoinLobby();
    }

    public void CrearSala() {
        if(crearInput.text.Length>0)
            PhotonNetwork.CreateRoom(crearInput.text,new RoomOptions() { MaxPlayers = 6});
    }

    public void UnirSala(string nombreSala) {
        PhotonNetwork.JoinRoom(nombreSala);
    }

    public override void OnJoinedRoom() {
        panelLobby.SetActive(false);
        panelSala.SetActive(true);
        nombreSala.text = " "+PhotonNetwork.CurrentRoom.Name;
        //PhotonNetwork.LoadLevel("Ovalo");
        
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        if (Time.time >= siguienteUpdate) {
            UpdateRoomList(roomList);
            siguienteUpdate = Time.time + tiempoEntreUpdates;
        }
        
    }

    private void UpdateRoomList(List<RoomInfo> roomList)
    {
        foreach (SalaItem salaItem in salaItemLista) {
            Destroy(salaItem.gameObject);
        }
        salaItemLista.Clear();

        foreach (RoomInfo salaInfo in roomList)
        {
            SalaItem nuevaSala = Instantiate(salaItemPrefab, objetoContenido);
            nuevaSala.SetNombreSala(salaInfo.Name);
            salaItemLista.Add(nuevaSala);
        }
    }

    public void OnClickSalirSala() {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        panelSala.SetActive(false);
        panelLobby.SetActive(true);
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }
}
