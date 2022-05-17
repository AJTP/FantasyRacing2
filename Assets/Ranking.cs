using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Ranking : MonoBehaviour
{
    public List<Coche> rankingFinal = new List<Coche>();
    public List<Coche> rankingMinuto = new List<Coche>();
    public Text textoRanking;

    public void AddCocheFinal(Coche coche) {
        rankingFinal.Add(coche);
        Debug.Log("Llega " + coche.name + " en posicion " + rankingFinal.Count);
        if (rankingFinal.Count == 6) { //SUSTITUIR POR Nº JUGADORES EN LA SALA
            //SE HA ACABADO LA PARTIDA
        }
    }

    public void AddCoche(Coche coche)
    {
        rankingMinuto.Add(coche);
        if (rankingMinuto.Count == 6){ //SUSTITUIR POR Nº JUGADORES EN LA SALA
            //TODOS LOS JUGADORES ESTÁN LISTOS COMIENZA LA PARTIDA

        }
    }
    public void ActualizarRanking() {
        GameObject[] coches = GameObject.FindGameObjectsWithTag("Coche");
        List<Coche> orden = new List<Coche>();
        foreach (GameObject x in coches) {
            switch (x.name) {
                case "JugadorAmbulancia(Clone)":
                    orden.Add(x.GetComponent<Ambulancia>());
                    break;
                case "JugadorBasura(Clone)":
                    orden.Add(x.GetComponent<CamionBasura>());
                    break;
                case "JugadorBomberos(Clone)":
                    orden.Add(x.GetComponent<CamionBomberos>());
                    break;
                case "JugadorF1(Clone)":
                    orden.Add(x.GetComponent<FormulaOne>());
                    break;
                case "JugadorPickup(Clone)":
                    orden.Add(x.GetComponent<Pickup>());
                    break;
                case "JugadorPolicia(Clone)":
                    orden.Add(x.GetComponent<Policia>());
                    break;
            }            
        }

       
        orden.ForEach(delegate (Coche c) {
            Debug.Log("Vuelta: "+c.vuelta +" Punto: "+ c.numPuntoControl +" Jugador: "+ c.nombreJugador);
        });
        string texto = "";
        int posicion = 1;
        foreach (Coche co in orden.OrderByDescending(c => c.vuelta).ThenByDescending(c => c.numPuntoControl))
        {
            texto += posicion + ". " + co.nombreJugador + "\n";
            posicion++;
        }
        textoRanking.text = texto;
    }
}
