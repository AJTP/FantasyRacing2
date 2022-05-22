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

    public Image backgroundImage;
    public Color colorResalto;

    ExitGames.Client.Photon.Hashtable propiedadesJugador = new ExitGames.Client.Photon.Hashtable();

    Player jugador;
    public void SetPlayerInfo(Player _jugador)
    {
        jugador = _jugador;
        UpdateRankingItem(jugador);
        PhotonNetwork.SetPlayerCustomProperties(propiedadesJugador);   
    }

    public void AplicarCambiosLocales()
    {
        backgroundImage.color = colorResalto;
    }

   /* public void UpdatePlayerInfo()
    {
        propiedadesJugador["jugadorNickName"] = jugador.NickName;
        PhotonNetwork.SetPlayerCustomProperties(propiedadesJugador);
    }*/

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (jugador == targetPlayer)
        {
            UpdateRankingItem(targetPlayer);
        }
    }

    private void UpdateRankingItem(Player targetPlayer)
    {
        if (targetPlayer.CustomProperties.ContainsKey("jugadorNickName"))
        {
            nombreJugador.text = targetPlayer.CustomProperties["jugadorNickName"].ToString();
            posicion.text = targetPlayer.CustomProperties["jugadorPosicion"].ToString();
            propiedadesJugador["jugadorNickName"] = targetPlayer.CustomProperties["jugadorNickName"];
        }
        else
        {
            propiedadesJugador["jugadorNickName"] = jugador.NickName;
            propiedadesJugador["jugadorPosicion"] = 0;
        }
    }
}