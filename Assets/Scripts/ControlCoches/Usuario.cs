using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Usuario
{
    private string _nombre;
    private string _email;
    private string _password;

    public string nombre { get => _nombre; set => _nombre = value; }
    public string email { get => _email; set => _email = value; }
    public string password { get => _password; set => _password = value; }

    public Usuario(string nombre, string email, string password)
    {
        this.nombre = nombre;
        this.email = email;
        this.password = password;
    }

    public Usuario()
    {
    }
}
