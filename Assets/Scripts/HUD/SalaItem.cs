using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SalaItem : MonoBehaviour
{
    public Text nombreSala;
    CreateAndJoinRooms manager;

    private void Start()
    {
        manager = FindObjectOfType<CreateAndJoinRooms>();
    }
    public void SetNombreSala(string nombre) {
        nombreSala.text = nombre;
    }

    public void OnClickItem()
    {
        manager.UnirSala(nombreSala.text);
    }
}
