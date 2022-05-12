using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlMenus : MonoBehaviour
{
    private string _usuario,_password,_email;
    private Jugador player;

    public string usuario { get => _usuario; set => _usuario = value; }
    public string password { get => _password; set => _password = value; }
    public string email { get => _email; set => _email = value; }

    private void Start()
    {
        player = new Jugador();
    }

    public void Login() {
        if (_email != null && _password != null)
        {
            player = new Jugador(usuario, password); //ESTO HAY QUE SUSTITUIRLO POR CARGAR DATOS DE LA BASE DE DATOS
            Debug.Log(player.email + player.password);
            //SI EL USUARIO SE CARGA CORRECTAMENTE ABRIR MENU
            SceneManager.LoadScene("Loading(2)");
            //SINO FEEDBACK DATOS INCORRECTOS
        }
        else {
            Debug.Log("NO ENTRA");
            //FEEDBACK RELLENAR CAMPOS
        }
    }

    public void Registrar() { 
        SceneManager.LoadScene("NuevoUsuario");
    }
}
