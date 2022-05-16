using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class SeleccionCampeon : MonoBehaviour
{
    public Spawn scriptSpawns;
    public GameObject canvas;
    public Button[] botones;
    public GameObject[] prefabs = new GameObject[6];
    private GameObject prefabElegido;

    // Start is called before the first frame update
    public void BotonPulsado(Button btn) {
        btn.image.color = Color.gray;
        btn.enabled = false;
        switch (btn.name) {
            case "Ambulancia":
                prefabElegido = prefabs[0];
                break;
            case "Bomberos":
                prefabElegido = prefabs[1];
                break;
            case "Basura":
                prefabElegido = prefabs[2];
                break;
            case "Formula":
                prefabElegido = prefabs[3];
                break;
            case "Policia":
                prefabElegido = prefabs[4];
                break;
            case "Pickup":
                prefabElegido = prefabs[5];
                break;
        }
    }

    public void ToGame() {
        canvas.SetActive(false);
        gameObject.SetActive(false);
        scriptSpawns.SpawnJugador(prefabElegido);        
    }
}
