using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
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

    private bool ok;
    private int veces = 0;
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

        foreach (Photon.Realtime.Player player in posiciones)
        {
            ItemRanking nuevoItemRanking = Instantiate(itemRankingPrefab, itemRankingParent);
            nuevoItemRanking.SetPlayerInfo(player,posiciones.IndexOf(player)+1);
            if (player == PhotonNetwork.LocalPlayer)
            {
                nuevoItemRanking.AplicarCambiosLocales();
            }
            listaItemsRanking.Add(nuevoItemRanking);
        }
    }

    public void ActualizarPosiciones()
    {
        posiciones.Clear();
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            posiciones.Add(player.Value);
        }

        posiciones = (List<Player>) posiciones.OrderByDescending(c => c.CustomProperties["jugadorVuelta"]).ThenByDescending(c => c.CustomProperties["jugadorPuntoControl"]).ThenByDescending(c =>c.CustomProperties["jugadorDistancia"]).ToList();

        UpdateListaJugadores();
    }

    private void Update()
    {
        if (PhotonNetwork.IsMasterClient)
        {
            ok = true;
            foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
            {
                if (player.Value.CustomProperties.ContainsKey("jugadorVuelta"))
                {
                    if ((int)player.Value.CustomProperties["jugadorVuelta"] < 4)
                    {
                        ok = false;
                    }
                }
                else {
                    ok = false;
                }
            }

            if (ok)
            {
                //TODOS LOS JUGADORES HAN ACABADO, DESPUÉS DE UN TIEMPO ENSEÑANDO EL RANKING FINAL PASAMOS A LA SIGUIENTE CARRERA
                if (veces == 0)
                {
                    StartCoroutine(TodosALaSiguiente());
                    veces++;
                }
            }
        }
    }

    private IEnumerator TodosALaSiguiente() {
        //ACTIVAMOS EL RANKING FINAL
        yield return new WaitForSeconds(10);
        switch (SceneManager.GetActiveScene().name) {
            case "Ovalo":
                PhotonNetwork.LoadLevel("Karting");
                break;
            case "Karting":
                PhotonNetwork.LoadLevel("Castillo");
                break;
            case "Castillo":
                //ACABA LA PARTIDA, RANKING FINAL DE PUNTOS TOTALES Y AL LOBBY
                yield return new WaitForSeconds(10);
                PhotonNetwork.LoadLevel("Rooms(3)");
                break;

        }
    }

    public int PuestoFinal() {
        int pos = 0;
        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            if (player.Value.CustomProperties.ContainsKey("jugadorPosicion"))
            {
                if ((int)player.Value.CustomProperties["jugadorPosicion"] > pos) {
                    pos = (int)player.Value.CustomProperties["jugadorPosicion"];
                }
            }
        }
        pos++;
        return pos;
    }
}
