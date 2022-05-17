using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Ranking : MonoBehaviour
{
    public List<Coche> rankingFinal = new List<Coche>();
    public List<Coche> rankingMinuto = new List<Coche>();

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
    public List<Coche> ActualizarRanking() {
        //A LO MEJOR NECESITO PASAR LOS COCHES POR REFERENCIA
        rankingMinuto.OrderBy(c =>c.vuelta).ThenBy(c => c.numPuntoControl);
        //ABRÍA QUE ACTUALIZAR EL RANKING DE TODOS LOS JUGADORES CON UN FOREACH SI TUVIERAMOS REFERENCIA
        return rankingMinuto;
    }
}
