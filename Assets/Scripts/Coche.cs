using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coche : MonoBehaviour
{
    public Rigidbody esfera;
    public float aceleracion = 8f, marchaAtras = 4f, velocidadMaxima = 50f, fuerzaGiro = 180f, gravedad = 10f, dragEnSuelo = 3f;

    public LayerMask suelo;
    public float longitudRayoSuelo = 0.5f;
    public Transform puntoRayoSuelo;
    public Transform ruedaIzquierda, ruedaDerecha;
    public float maximaRotacionRuedas = 25f;


    private float multiplicador = 1000f;
    private float velocidadInput, giroInput;
    private bool tocandoSuelo;
    #region INFORMACIÓN JUGADOR
    public int posicion;
    private int idJugador;
    private string nombreJugador;
    #endregion
    #region STATS COCHE
    //COOLDOWNS
    protected bool[] isCD = new bool[4];
    protected float[] coolDowns = new float[4];
    protected float[] timerCD= new float[4];
    public Image[] imagenes = new Image[4];

    public int vida,vidaMaxima;
    #endregion
    public void RecogerInputMovimientoBasico() {
        velocidadInput = 0f;
        //RECOGIDA ACELERACION
        if (Input.GetAxis("Vertical") > 0)
        {
            //ACELERA HACIA DELANTE
            velocidadInput = Input.GetAxis("Vertical") * aceleracion * multiplicador;
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            //ACELERA MARCHA ATRAS
            velocidadInput = Input.GetAxis("Vertical") * marchaAtras * multiplicador;
        }


        //RECOGIDA DIRECCION
        giroInput = Input.GetAxis("Horizontal");

        if (tocandoSuelo)
        {
            transform.rotation = Quaternion.Euler(transform.eulerAngles + new Vector3(0, giroInput * fuerzaGiro * Time.deltaTime * Input.GetAxis("Vertical"), 0f));
        }

        //ROTACION RUEDAS #ESTETICO
        ruedaIzquierda.localRotation = Quaternion.Euler(ruedaIzquierda.localRotation.eulerAngles.x, (giroInput * maximaRotacionRuedas) - 180, ruedaIzquierda.localRotation.eulerAngles.z);
        ruedaDerecha.localRotation = Quaternion.Euler(ruedaDerecha.localRotation.eulerAngles.x, giroInput * maximaRotacionRuedas, ruedaDerecha.localRotation.eulerAngles.z);

        transform.position = esfera.position;
    }

    public void AplicarVelocidad() {
        tocandoSuelo = false;
        RaycastHit hit;

        //COMPROBACION TOCANDO SUELO
        if (Physics.Raycast(puntoRayoSuelo.position, -transform.up, out hit, longitudRayoSuelo, suelo))
        {
            tocandoSuelo = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }

        if (tocandoSuelo)
        {
            esfera.drag = dragEnSuelo;
            if (Mathf.Abs(velocidadInput) > 0)
            {
                //SUMAR VELOCIDAD
                esfera.AddForce(transform.forward * velocidadInput);
            }
        }else{
            //ESTA EN EL AIRE
            esfera.drag = 0.1f;
            esfera.AddForce(Vector3.up * -gravedad * 100f);
        }
    }


    public void RecibirBoost(float cantidad){
        //NO FUNCIONA
        //esfera.AddForce(transform.forward * cantidad);
    }

    public void RecibirStun(float tiempo){
        
    }

    public void SoltarPrefab(){

    }
}
