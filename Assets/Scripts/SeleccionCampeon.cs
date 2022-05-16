using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class SeleccionCampeon : MonoBehaviour
{
    public Button[] botones;
    // Start is called before the first frame update
    public void BotonPulsado(Button btn) {
        btn.image.color = Color.gray;
        btn.enabled = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void ToGame() {
        PhotonNetwork.LoadLevel("Ovalo");
    }
}
