using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLeader : MonoBehaviour
{
    public Text nombre, tiempo;

    public void SetDatosItem(string _nombre,int _tiempo) {
        nombre.text = _nombre;
        tiempo.text = ""+_tiempo;
    }
}
