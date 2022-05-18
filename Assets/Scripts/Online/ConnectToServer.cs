using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public InputField nombreInput;
    public InputField passwordInput;

    public Text textoBoton;

    public void OnClickConnect()
    {
        if (nombreInput.text.Length > 0) {
            PhotonNetwork.NickName = nombreInput.text;
            textoBoton.text = "Conectando...";
            PhotonNetwork.ConnectUsingSettings();
        }
    }

    public override void OnConnectedToMaster() {
        SceneManager.LoadScene("Rooms(3)");
    }

    void Start()
    {
        
    }

    
}
