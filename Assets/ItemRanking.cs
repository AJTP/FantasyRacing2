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
        UpdateRankingItem(jugador);
    }

    public void AplicarCambiosLocales()
    {
        backgroundImage.color = colorResalto;
    }

    public void UpdatePlayerInfo(Coche _coche)
    {
        propiedadesJugador["infoRanking"] = new ElementoRanking(jugador.NickName,_coche.hp,_coche.posicion);
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
        if (targetPlayer.CustomProperties.ContainsKey("infoRanking"))
        {
            ElementoRanking info = (ElementoRanking)targetPlayer.CustomProperties["infoRanking"];
            nombreJugador.text = info.Nombre;
            posicion.text = info.Posicion.ToString();
            vida.text = info.Vida.ToString();

            propiedadesJugador["infoRanking"] = (ElementoRanking)targetPlayer.CustomProperties["infoRanking"];
        }
        else
        {
            propiedadesJugador["infoRanking"] = new ElementoRanking(jugador.NickName, carro.hp, carro.posicion);
        }
    }
}

public class ElementoRanking {
    private string nombre;
    private int vida;
    private int posicion;

    public string Nombre { get => nombre; set => nombre = value; }
    public int Posicion { get => posicion; set => posicion = value; }
    public int Vida { get => vida; set => vida = value; }

    public ElementoRanking(string nombre, int vida, int posicion)
    {
        this.nombre = nombre;
        this.vida = vida;
        this.posicion = posicion;
    }
}
