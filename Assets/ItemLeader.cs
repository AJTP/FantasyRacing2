using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLeader : MonoBehaviour
{
    public Text nombre, tiempo;

    public void SetDatosItem(string _nombre,int _tiempo) {
        nombre.text = _nombre;
        tiempo.text = SecsToMin(_tiempo);
    }

    public string SecsToMin(int segundos) {
        int min;
        min = segundos / 60;
        segundos = segundos - min * 60;
        return string.Format("{0:D2}:{1:D2}",min,segundos);
    }
}
