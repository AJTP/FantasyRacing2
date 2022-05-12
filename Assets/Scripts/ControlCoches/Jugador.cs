using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador
{
    private int _posicion;
    private int _idJugador;
    private string _nombreJugador;
    private string _usuario, _password,_email;
    private int _vuelta;
    private int _puntosControl;

    public int posicion { get => _posicion; set => _posicion = value; }
    public int idJugador { get => _idJugador; set => _idJugador = value; }
    public string nombreJugador { get => _nombreJugador; set => _nombreJugador = value; }
    public int vuelta { get => _vuelta; set => _vuelta = value; }
    public int puntosControl { get => _puntosControl; set => _puntosControl = value; }
    public string usuario { get => _usuario; set => _usuario = value; }
    public string password { get => _password; set => _password = value; }
    public string email { get => _email; set => _email = value; }

    public Jugador(string usuario, string password)
    {
        _usuario = usuario;
        _password = password;
    }

    public Jugador()
    {
    }
}
