using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using System.Collections.Generic;

public class Coche : MonoBehaviour
{
    ExitGames.Client.Photon.Hashtable propiedadesJugador = new ExitGames.Client.Photon.Hashtable();
    //ESTA CLASE RECOGE LAS CARACTERISTICAS COMUNES A TODOS LOS COCHES TALES COMO EL MOVIMIENTO, EFECTOS, ETC
    public Rigidbody esfera;
    public int id;
    public string nickJugador;
    private static int idContador = 0;

    #region ESTADISTICAS BASICAS

    public float aceleracion = 8f;
    public float marchaAtras = 4f;
    public float velocidadMaxima = 50f;
    public float fuerzaGiro = 180f;
    public float gravedad = 10f;
    public float dragEnSuelo = 3f;
    public int hp=50;
    public int maxHP=100;
    public int posicion;
    public bool boosted = false;
    public float cantidadBoost;


    #endregion

    #region UTILIDADES MOVIMIENTO

    public LayerMask suelo, carretera;
    public float longitudRayoSuelo = 0.5f;
    private bool tocandoSuelo;
    public Transform puntoRayoSuelo;
    public Transform ruedaIzquierda, ruedaDerecha;
    public float maximaRotacionRuedas = 25f;
    private float multiplicador = 1000f;
    private float velocidadInput, giroInput;

    #endregion

    #region COOLDOWNS

    protected bool[] isCD = new bool[4];
    protected float[] coolDowns = new float[4];
    protected float[] timerCD = new float[4];

    #endregion

    #region HUD

    public Image[] imagenes = new Image[4];

    public Text contadorVueltas;


    #endregion

    #region INFORMACION JUGADOR
    private string nombreJugador;
    private int vuelta = 0;
    private int numPuntoControl;
    private float distanciaSiguientePunto;
    private GameObject puntosControl;
    private GameObject rank;
    #endregion

    #region UTILIDADES HABILIDADES
        public Transform puntoPrefabs;
    #endregion

    #region ONLINE
    protected PhotonView vista;
    #endregion


    //=================FUNCIONES=================

    #region MOVIMIENTO COCHE
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

        transform.position = esfera.position - new Vector3(0, 0.275f, 0);


        //CAMBIO CAMARA (RETROVISOR)
        /*if (Input.GetKey(KeyCode.R))
        {
            camarillas.transform.GetChild(0).gameObject.SetActive(false);
            camarillas.transform.GetChild(2).gameObject.SetActive(true);
        } else {
            camarillas.transform.GetChild(2).gameObject.SetActive(false);
            camarillas.transform.GetChild(0).gameObject.SetActive(true);
        }*/
    }
    public void AplicarVelocidad()
    {
        tocandoSuelo = false;
        RaycastHit hit;

        //COMPROBACION TOCANDO SUELO
        if (Physics.Raycast(puntoRayoSuelo.position, -transform.up, out hit, longitudRayoSuelo, carretera))
        {
            tocandoSuelo = true;

            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
        }
        else if (Physics.Raycast(puntoRayoSuelo.position, -transform.up, out hit, longitudRayoSuelo, suelo))
        {

            tocandoSuelo = true;
            transform.rotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;
            velocidadInput /= 2;

        }

        if (tocandoSuelo)
        {
            esfera.drag = dragEnSuelo;
            if (Mathf.Abs(velocidadInput) > 0)
            {
                //SUMAR VELOCIDAD
                esfera.AddForce(transform.forward * velocidadInput);
            }
        }
        else
        {
            //ESTA EN EL AIRE
            esfera.drag = 0.1f;
            esfera.AddForce(Vector3.up * -gravedad * 100f);
        }
    }
    #endregion


    #region ACTUALIZACION HUD
    public void SumaVuelta()
    {
        vuelta++;
        propiedadesJugador["jugadorVuelta"] = vuelta;
        PhotonNetwork.SetPlayerCustomProperties(propiedadesJugador);
        ActualizarRanking();
        if (vuelta <=3)
        {
            contadorVueltas.text = vuelta + "/3";
        }
    }

    public void ActualizaControl(int n)
    {
        numPuntoControl=n;
        propiedadesJugador["jugadorPuntoControl"] = numPuntoControl;
        PhotonNetwork.SetPlayerCustomProperties(propiedadesJugador);
        ActualizarRanking();

    }

    public void ActualizarRanking() {
        //ESTA FUNCION ACTUALIZA EL HUD PARA VER EL RANKING IN GAME
        
        rank.GetComponent<Ranking>().ActualizarPosiciones();
        this.posicion = rank.GetComponent<Ranking>().MiPosicion(PhotonNetwork.LocalPlayer);
        rank.GetComponent<Ranking>().UpdateListaJugadores();
    }

    public void CargarCooldowns(int cdh1,int cdh2,int cdh3,int cdh4) {
        coolDowns[0] = cdh1;
        coolDowns[1] = cdh2;
        coolDowns[2] = cdh3;
        coolDowns[3] = cdh4;
        for (int i = 0; i < timerCD.Length; i++)
        {
            timerCD[i] = coolDowns[i];
        }
    }
    #endregion

    #region EFECTOS SOBRE JUGADOR (HABILIDADES)

    public void RecibirStun(float tiempo) {

    }

    public void SoltarPrefab(GameObject prefab) {
        Instantiate(prefab,puntoPrefabs.position,Quaternion.identity);
    }
    protected void ReducirCoolDown(int i)
    {
        if (timerCD[i] < coolDowns[i])
        {
            imagenes[i].color = Color.red;
            timerCD[i] += Time.deltaTime;
            imagenes[i].fillAmount = timerCD[i] / coolDowns[i];
        }
        else if (timerCD[i] >= coolDowns[i])
        {
            imagenes[i].color = Color.cyan;
            timerCD[i] = coolDowns[i];
            imagenes[i].fillAmount = 1;
            isCD[i] = false;
        }
    }

    public int RecogerInputHabilidades()
    {
        if (Input.GetKeyDown("u"))
        {
            return 0;
        }
        else if (Input.GetKeyDown("i"))
        {
            return 1;
        }
        else if (Input.GetKeyDown("o"))
        {
            return 2;
        }
        else if (Input.GetKeyDown("p"))
        {
            return 3;
        }

        return 5;
    }

    public void ModificarSize(int factor) {
        Vector3 escala = new Vector3(transform.localScale.x*factor, transform.localScale.y * factor, transform.localScale.z * factor);
        transform.localScale = escala;
    }

    #endregion

    #region ONLINE
    public void CargarVista() {
        GameManager.Instancia.AddCoche(this);
        id = idContador;
        idContador++;
        rank = GameObject.Find("RANKING");
        puntosControl = GameObject.Find("PuntosControl");
        vista = GetComponent<PhotonView>();
        propiedadesJugador["jugadorVuelta"] = 0;
        propiedadesJugador["jugadorDistancia"] = 0;
        propiedadesJugador["jugadorPuntoControl"] = numPuntoControl;
        PhotonNetwork.SetPlayerCustomProperties(propiedadesJugador);
        ActualizarRanking();
    }
    #endregion

    #region INFORMACION JUGADOR
    public void CargarPuntosControl() {
        TrackCheckpoints tracker = GameObject.Find("Tracking").GetComponent<TrackCheckpoints>();
        tracker.AddCoche(this);
        tracker.AddCocheTransform(esfera.transform);
    }
    #endregion

    public IEnumerator DesactivarBoost() {
        yield return new WaitForSeconds(2f);
        boosted = false;
    }

    public void SetNickJugador(string nick) {
        nickJugador = nick;
    }

    public void ActualizarDistanciaPuntoControl() {
        distanciaSiguientePunto = Vector3.Distance(transform.position, puntosControl.transform.GetChild(numPuntoControl).transform.position);
        propiedadesJugador["jugadorDistancia"] = distanciaSiguientePunto;
        PhotonNetwork.SetPlayerCustomProperties(propiedadesJugador);
        //ActualizarRanking();
    }
    
}
    