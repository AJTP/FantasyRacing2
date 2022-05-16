using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instancia;

    public List<Coche> coches = new List<Coche>();
    private List<Transform> spawns = new List<Transform>();

    public static GameManager Instancia {
        get{
            if (_instancia is null)
                Debug.Log("El GameManager es nulo");
            return _instancia;
        }
    }

    private void Awake()
    {
        _instancia = this;
    }


    void Start()
    {
        

    }
  
    public void AddCoche(Coche coche) {
        coches.Add(coche);
    }

    public void CargarSpawns()
    {
        if (spawns.Count == 0) {
            GameObject padre = GameObject.Find("Spawner");
            for (int i = 0; i < padre.transform.childCount; i++)
            {
                spawns.Add(padre.transform.GetChild(i));
            }
        }        
    }

    public Transform GetRandomSpawn()
    {
        System.Random rnd = new System.Random();
        int indice = rnd.Next(0, spawns.Count - 1);
        Transform t = spawns[indice];
        return t;
    }
}