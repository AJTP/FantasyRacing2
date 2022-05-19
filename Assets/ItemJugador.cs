using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class ItemJugador : MonoBehaviourPunCallbacks
{
    public Text nombreJugador;
    public Image backgroundImage;
    public Color colorResalto;
    public GameObject botonFlechaIzquierda, botonFlechaDerecha;

    ExitGames.Client.Photon.Hashtable propiedadesJugador = new ExitGames.Client.Photon.Hashtable();
    public Image avatarJugador;
    public Sprite[] avatares;

    Player jugador;
    public void SetPlayerInfo(Player _jugador) {
        nombreJugador.text = _jugador.NickName;
        jugador = _jugador;
        UpdatePlayerItem(jugador);
    }

    public void AplicarCambiosLocales() {
        backgroundImage.color = colorResalto;
        botonFlechaIzquierda.SetActive(true);
        botonFlechaDerecha.SetActive(true);
    }

    public void OnClickFlechaIzquierda() {
        if ((int)propiedadesJugador["avatarJugador"] == 0)
        {
            propiedadesJugador["avatarJugador"] = avatares.Length - 1;
        }
        else {
            propiedadesJugador["avatarJugador"] = (int)propiedadesJugador["avatarJugador"] - 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(propiedadesJugador);
    }

    public void OnClickFlechaDerecha()
    {
        if ((int)propiedadesJugador["avatarJugador"] == avatares.Length - 1)
        {
            propiedadesJugador["avatarJugador"] = 0;
        }
        else
        {
            propiedadesJugador["avatarJugador"] = (int)propiedadesJugador["avatarJugador"] + 1;
        }
        PhotonNetwork.SetPlayerCustomProperties(propiedadesJugador);
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        if (jugador == targetPlayer) {
            UpdatePlayerItem(targetPlayer);
        }
    }

    private void UpdatePlayerItem(Player targetPlayer)
    {
        if (targetPlayer.CustomProperties.ContainsKey("avatarJugador")) {
            avatarJugador.sprite = avatares[(int)targetPlayer.CustomProperties["avatarJugador"]];
            propiedadesJugador["avatarJugador"] = (int)targetPlayer.CustomProperties["avatarJugador"];
        }
        else
        {
            propiedadesJugador["avatarJugador"] = 0;
        }
    }
}
