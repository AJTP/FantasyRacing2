using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime;
public class Spawn : MonoBehaviour
{

    public GameObject[] prefabsJugadores;
    public Transform[] puntosSpawn;
    public Text cuentaAtras;
    public int i = 5;

    private GameObject miJugador;
    GameObject puntosControl;
    GameObject meta;
    List<GameObject> puntos = new List<GameObject>();
    ExitGames.Client.Photon.Hashtable propiedadesJugador = new ExitGames.Client.Photon.Hashtable();
    void Start()
    {
        StartCoroutine(CuentaAtras());
        propiedadesJugador = PhotonNetwork.LocalPlayer.CustomProperties;
        GameObject jugadorAlSpawn = prefabsJugadores[(int)PhotonNetwork.LocalPlayer.CustomProperties["avatarJugador"]];
        int spawn = DameUnSpawn();
        Transform puntoSpawn = puntosSpawn[spawn];
        propiedadesJugador["jugadorSpawn"] = spawn;
        PhotonNetwork.SetPlayerCustomProperties(propiedadesJugador);
        miJugador = PhotonNetwork.Instantiate(jugadorAlSpawn.name, puntoSpawn.position, puntoSpawn.rotation);
        miJugador.GetComponent<Coche>().SetNickJugador(PhotonNetwork.LocalPlayer.NickName);


        GameObject camara = GameObject.FindWithTag("MainCamera");
        if (camara != null)
        {
            camara.GetComponent<CameraFollower>().Objetivo = miJugador.transform;
            camara.GetComponent<CameraFollower>().PuntoCamara = miJugador.GetComponent<ControlCamaras>().puntoNormal;

        }
        GameObject camaraMinimapa = GameObject.FindWithTag("MiniCamera");
        camaraMinimapa.transform.position = miJugador.GetComponent<ControlCamaras>().puntoMinimapa.transform.position;
        GameObject camaraRetro = GameObject.FindWithTag("RetroCamera");
        camaraRetro.GetComponent<CameraFollower>().Objetivo = miJugador.transform;
        camaraRetro.GetComponent<CameraFollower>().PuntoCamara = miJugador.GetComponent<ControlCamaras>().puntoRetrovisor;
        camaraRetro.SetActive(false);




        //PUNTOS DE CONTROL CARGADOS
        puntosControl = GameObject.Find("PuntosControl");
        for (int i = 0; i < puntosControl.transform.childCount; i++)
        {
            puntos.Add(puntosControl.transform.GetChild(i).gameObject);
        }
    }

    private int DameUnSpawn() {
        bool ok;
        int numeroRandom = -1;
        while (true) {
            ok = true;
            numeroRandom = Random.Range(0, puntosSpawn.Length);
            foreach (KeyValuePair<int, Player> player in PhotonNetwork.CurrentRoom.Players)
            {
                if (player.Value.CustomProperties.ContainsKey("jugadorSpawn"))
                {
                    if ((int)player.Value.CustomProperties["jugadorSpawn"] == numeroRandom)
                    {
                        ok = false;
                        break;
                    }
                }
            }
            if (ok)
                break;
        }
        return numeroRandom;
    }

    private IEnumerator CuentaAtras() {
        i = 5;
        while (i > 0) {
            cuentaAtras.text = i.ToString();
            yield return new WaitForSeconds(1);
            i--;
        }
        cuentaAtras.text = "GO!!";
        yield return new WaitForSeconds(1);
        cuentaAtras.gameObject.SetActive(false);
    }
}