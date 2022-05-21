using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;

public class Ranking : MonoBehaviour
{
    //NUEVO RANKING -------------------------- 19/05

    private List<Photon.Realtime.Player> posiciones = new List<Photon.Realtime.Player>();
    private List<ItemRanking> listaItemsRanking = new List<ItemRanking>();
    public ItemRanking itemRankingPrefab;
    public Transform itemRankingParent;

    ExitGames.Client.Photon.Hashtable propiedadesJugador = new ExitGames.Client.Photon.Hashtable();

    public void UpdateListaJugadores()
    {
        foreach (ItemRanking item in listaItemsRanking)
        {
            Destroy(item.gameObject);
            Destroy(item);
        }
        listaItemsRanking.Clear();

        if (PhotonNetwork.CurrentRoom == null)
        {
            return;
        }

        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            ItemRanking nuevoItemRanking = Instantiate(itemRankingPrefab, itemRankingParent);
            nuevoItemRanking.SetPlayerInfo(player.Value);
            if (player.Value == PhotonNetwork.LocalPlayer)
            {
                nuevoItemRanking.AplicarCambiosLocales();
            }
            listaItemsRanking.Add(nuevoItemRanking);
        }  
    }

    public int MiPosicion(Photon.Realtime.Player jugador) {

        return posiciones.IndexOf(jugador)+1;
    }

    public void ActualizarPosiciones()
    {
        posiciones.Clear();
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            posiciones.Add(player.Value);
        }

        posiciones.OrderByDescending(c => (int)c.CustomProperties["jugadorVuelta"]).ThenByDescending(c => (int)c.CustomProperties["jugadorPuntoControl"]).ThenByDescending(c => (int)c.CustomProperties["jugadorDistancia"]);
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            propiedadesJugador["jugadorPosicion"] = posiciones.IndexOf(player.Value)+1;
            player.Value.SetCustomProperties(propiedadesJugador);
        }
    }
}
