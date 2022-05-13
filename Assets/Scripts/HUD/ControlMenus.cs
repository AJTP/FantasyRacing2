using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControlMenus : MonoBehaviour
{
    private bool todoOk;
    public Text feedback;
    public InputField[] inputs;

    private string _usuario, _password, _email, _comprobarPWD;
    private Usuario player;

    private void Start()
    {
        QualitySettings.vSyncCount = 1;
        player = new Usuario();
    }
    //=======================ESCENA INICIO SESION=======================

    public void Login()
    {
        if (_email != null && _password != null)
        {
            //player = new Usuario(usuario, password); //ESTO HAY QUE SUSTITUIRLO POR CARGAR DATOS DE LA BASE DE DATOS
            //SI EL USUARIO SE CARGA CORRECTAMENTE ABRIR MENU
            SceneManager.LoadScene("Loading(2)");
         }
        else
        {
            MostrarFeedback("Rellena todos los campos");
        }
    }

    public void ToRegistrar()
    {
        SceneManager.LoadScene("NuevoUsuario(0)");
    }

    public void ComprobarDatosLogin()
    {
        feedback.gameObject.SetActive(false);
        todoOk = true;
        //PASSWORD
        if (inputs[1].textComponent.text.Length>0)
        {
            inputs[1].textComponent.color = Color.black;
            _password = inputs[1].textComponent.text;
        }
        else
        {
            if (inputs[1].textComponent.text.Length > 0)
            {
                inputs[1].textComponent.color = Color.red;
                todoOk = false;
                MostrarFeedback("Rellena la contrase�a");
            }
        }

        //CORREO
        if (inputs[0].textComponent.text.Length > 0)
        {
            inputs[0].textComponent.color = Color.black;
            _email = inputs[0].textComponent.text;
        }
        else
        {
            if (inputs[0].textComponent.text.Length > 0)
            {
                inputs[0].textComponent.color = Color.red;
                todoOk = false;
                MostrarFeedback("Rellena el correo");
            }
        }
    }



    //=======================ESCENA CREAR USUARIO=======================
    public void ToInicioSesion()
    {
        SceneManager.LoadScene("InicioSesion(1)");
    }

    public void CrearUsuario() {
        //REVISAR COMO SE GUARDA LA PWD
        if (todoOk) {
            //GUARDO LOS DATOS EN LA BBDD
        }        
    }

    public void ComprobarDatos()
    {
        feedback.gameObject.SetActive(false);
        todoOk = true;
        //PASSWORD
        if (inputs[2].textComponent.text.Length < 8)
        {
            if (inputs[2].textComponent.text.Length > 0)
            {
                inputs[2].textComponent.color = Color.red;
                todoOk = false;
                MostrarFeedback("La contrase�a debe tener m�s de 8 caracteres");
            }
        }
        else if (!inputs[2].textComponent.text.Equals(inputs[3].textComponent.text))
        {
            if (inputs[2].textComponent.text.Length > 0 && inputs[3].textComponent.text.Length > 0)
            {
                inputs[2].textComponent.color = Color.red;
                inputs[3].textComponent.color = Color.red;
                todoOk = false;
                MostrarFeedback("Las contrase�as no coinciden");
            }
        }
        else
        {
            inputs[2].textComponent.color = Color.black;
            inputs[3].textComponent.color = Color.black;
            _password = inputs[2].textComponent.text;
        }

        //CORREO
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(inputs[1].textComponent.text);
        if (!match.Success)
        {
            if (inputs[1].textComponent.text.Length > 0)
            {
                inputs[1].textComponent.color = Color.red;
                todoOk = false;
                MostrarFeedback("Introduce un correo v�lido");
            }
        }
        else
        {
            inputs[1].textComponent.color = Color.black;
            _email = inputs[1].textComponent.text;
        }

        //NOMBRE
        if (inputs[0].textComponent.text.Length < 4)
        {
            if (inputs[0].textComponent.text.Length > 0)
            {
                inputs[0].textComponent.color = Color.red;
                todoOk = false;
                MostrarFeedback("El nombre debe de tener m�s de 4 caracteres");
            }
        }
        else
        {
            inputs[0].textComponent.color = Color.black;
            _usuario = inputs[0].textComponent.text;
        }
    }

    public void MostrarFeedback(string texto)
    {
        feedback.gameObject.SetActive(true);
        feedback.text = texto;
    }
}
