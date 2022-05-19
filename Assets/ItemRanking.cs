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
    public Text vida;

    public Image backgroundImage;
    public Color colorResalto;

    ExitGames.Client.Photon.Hashtable propiedadesJugador = new ExitGames.Client.Photon.Hashtable();

    Player jugador;
    Coche carro;
    public void SetPlayerInfo(Player _jugador,Coche _coche)
    {
        nombreJugador.text = _jugador.NickName;
        jugador = _jugador;
        carro = _coche;
        propiedadesJugador["jugadorNickName"] = jugador.NickName;
        propiedadesJugador["jugadorHP"] = _coche.hp;
        propiedadesJugador["jugadorPosicion"] = _coche.posicion;
        PhotonNetwork.SetPlayerCustomProperties(propiedadesJugador);
        UpdateRankingItem(jugador);
    }

    public void AplicarCambiosLocales()
    {
        backgroundImage.color = colorResalto;
    }

    public void UpdatePlayerInfo(Coche _coche)
    {
        propiedadesJugador["jugadorNickName"] = jugador.NickName;
        propiedadesJugador["jugadorHP"] = _coche.hp;
        propiedadesJugador["jugadorPosicion"] = _coche.posicion;
        PhotonNetwork.SetPlayerCustomProperties(propiedadesJugador);
    }

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
            nombreJugador.text = propiedadesJugador["jugadorNickName"].ToString();
            vida.text = propiedadesJugador["jugadorHP"].ToString();
            posicion.text = propiedadesJugador["jugadorPosicion"].ToString();

            propiedadesJugador["jugadorNickName"] = targetPlayer.CustomProperties["jugadorNickName"];
            propiedadesJugador["jugadorHP"] = targetPlayer.CustomProperties["jugadorHP"];
            propiedadesJugador["jugadorPosicion"] = targetPlayer.CustomProperties["jugadorPosicion"];
        }
        else
        {
            Debug.Log("NO SE HA ENCONTRADO UN OBJETO DEL TIPO infoRanking");
            //propiedadesJugador["jugadorNickName"] = jugador.NickName;
            //propiedadesJugador["jugadorHP"] = _coche.hp;
            //propiedadesJugador["jugadorPosicion"] = _coche.posicion;    
        }
    }
}