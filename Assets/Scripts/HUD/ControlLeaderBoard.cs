using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PlayFab;
using PlayFab.ClientModels;
public class ControlLeaderBoard : MonoBehaviour
{
    public Text nombreCircuito;
    public Transform itemParent;
    public ItemLeader itemLeaderPrefab;
    private string[] nombres = {"Leaderboard Ovalo", "Leaderboard Karting", "Leaderboard Castillo" };
    private int indice=0;
    private List<ItemLeader> itemsLeader = new List<ItemLeader>();

    private void Start()
    {
        ActualizarVista();
    }
    public void CerrarLeaderBoard()
    {
        this.gameObject.SetActive(false);
    }

    public void SiguienteCircuito()
    {
        indice++;
        if (indice > 2)
            indice = 0;
        ActualizarVista();
    }

    public void AnteriorCircuito()
    {
        indice--;
        if (indice < 0)
            indice = 2;
        ActualizarVista();

    }

    public void ActualizarVista() {
        nombreCircuito.text = nombres[indice];

        //VACÍO LA TABLA
        foreach (ItemLeader item in itemsLeader)
        {
            Destroy(item.gameObject);
            Destroy(item);
        }
        itemsLeader.Clear();

        //COJO LOS DATOS

        var request = new GetLeaderboardRequest
        {
            StatisticName = nombres[indice],
            StartPosition = 0,
            MaxResultsCount = 5
        };

        PlayFabClientAPI.GetLeaderboard(request, DatosCargados,null);

        
    }

    public void DatosCargados(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
            ItemLeader nuevoItem = Instantiate(itemLeaderPrefab, itemParent);
            nuevoItem.SetDatosItem(item.DisplayName,item.StatValue);
            itemsLeader.Add(nuevoItem);
        }
    }

}
