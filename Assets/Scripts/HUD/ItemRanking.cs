using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;


public class ItemRanking : MonoBehaviourPunCallbacks
{
    public Text nombreJugador;
    public Text posicion;
    public Text puntuacion;

    public Image backgroundImage;
    public Color colorResalto;

    ExitGames.Client.Photon.Hashtable propiedadesJugador = new ExitGames.Client.Photon.Hashtable();
    public void SetPlayerInfo(Player _jugador,int puesto)
    {
        UpdateRankingItem(_jugador, puesto);
        PhotonNetwork.SetPlayerCustomProperties(propiedadesJugador);   
    }

    public void SetFinalInfo(Player _jugador, int puesto)
    {
        UpdateFinalItem(_jugador, puesto);
        PhotonNetwork.SetPlayerCustomProperties(propiedadesJugador);
    } 
    
    public void SetDefinitiveInfo(Player _jugador, int puntos)
    {
        UpdateDefinitiveItem(_jugador, puntos);
        PhotonNetwork.SetPlayerCustomProperties(propiedadesJugador);
    }



    public void AplicarCambiosLocales()
    {
        backgroundImage.color = colorResalto;
        nombreJugador.text = PhotonNetwork.LocalPlayer.NickName;
    }

   /* public void UpdatePlayerInfo()
    {
        propiedadesJugador["jugadorNickName"] = jugador.NickName;
        PhotonNetwork.SetPlayerCustomProperties(propiedadesJugador);
    }*/

    private void UpdateRankingItem(Player targetPlayer,int puesto)
    {
        propiedadesJugador = PhotonNetwork.LocalPlayer.CustomProperties;
        if (targetPlayer.CustomProperties.ContainsKey("jugadorNickName"))
        {
            nombreJugador.text = targetPlayer.NickName;
            posicion.text = ""+puesto;
            propiedadesJugador["jugadorNickName"] = targetPlayer.NickName;
        }
        else
        {
            propiedadesJugador["jugadorNickName"] = targetPlayer.NickName;
            propiedadesJugador["jugadorPosicion"] = 0;
        }
    }

    private void UpdateFinalItem(Player targetPlayer, int puesto)
    {
        propiedadesJugador = PhotonNetwork.LocalPlayer.CustomProperties;
        if (targetPlayer.CustomProperties.ContainsKey("jugadorNickName"))
        {
            nombreJugador.text = targetPlayer.NickName;
            posicion.text = targetPlayer.CustomProperties["jugadorPFinal"]+"";
            propiedadesJugador["jugadorNickName"] = targetPlayer.NickName;
        }
    }

    private void UpdateDefinitiveItem(Player targetPlayer, int puntos)
    {
        propiedadesJugador = PhotonNetwork.LocalPlayer.CustomProperties;
        if (targetPlayer.CustomProperties.ContainsKey("jugadorNickName"))
        {
            nombreJugador.text = targetPlayer.NickName;
            posicion.gameObject.SetActive(false);
            puntuacion.gameObject.SetActive(true);
            puntuacion.text = targetPlayer.CustomProperties["jugadorPunFinal"] + "";
            propiedadesJugador["jugadorNickName"] = targetPlayer.NickName;
        }
    }
}