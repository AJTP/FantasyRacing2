using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    public Rigidbody esfera;

    public float aceleracion=8f, marchaAtras=4f, velocidadMaxima=50f, fuerzaGiro=180f;

    public float velocidad = 2f;
    private void Start()
    {
        esfera.transform.parent = null;
    }

    private void Update()
    {
        transform.position = esfera.position;
    }

    private void FixedUpdate()
    {
        esfera.AddForce(transform.forward * aceleracion);
    }
}
