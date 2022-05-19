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


    private List<ItemRanking> listaItemsRanking = new List<ItemRanking>();
    public ItemRanking itemRankingPrefab;
    public Transform itemRankingParent;


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

        GameObject[] coches = GameObject.FindGameObjectsWithTag("Coche");

        foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
        {
            ItemRanking nuevoItemRanking = Instantiate(itemRankingPrefab, itemRankingParent);
            Coche tipoCoche = new Coche();
            foreach (GameObject x in coches)
            {
                if (true)//SI EL COCHE ES EL DE ESTE JUGADOR
                { 
                    switch (x.name)
                    {
                        case "JugadorAmbulancia(Clone)":
                            tipoCoche = x.GetComponent<Ambulancia>();
                            break;
                        case "JugadorBasura(Clone)":
                            tipoCoche = x.GetComponent<CamionBasura>();
                            break;
                        case "JugadorBomberos(Clone)":
                            tipoCoche = x.GetComponent<CamionBomberos>();
                            break;
                        case "JugadorF1(Clone)":
                            tipoCoche = x.GetComponent<FormulaOne>();
                            break;
                        case "JugadorPickup(Clone)":
                            tipoCoche = x.GetComponent<Pickup>();
                            break;
                        case "JugadorPolicia(Clone)":
                            tipoCoche = x.GetComponent<Policia>();
                            break;
                    }
                }
            }
            nuevoItemRanking.SetPlayerInfo(player.Value, tipoCoche);
            if (player.Value == PhotonNetwork.LocalPlayer)
            {
                nuevoItemRanking.AplicarCambiosLocales();
            }
            listaItemsRanking.Add(nuevoItemRanking);
        }  
    }
}
