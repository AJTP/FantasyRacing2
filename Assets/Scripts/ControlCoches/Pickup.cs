using UnityEngine;
using Photon.Pun;

public class Pickup : Coche
{
    public GameObject prefab, prefab2,prefab3;
    public GameObject body;
    public Color colorBoost,colorNormal;
    public AudioClip[] sonidos = new AudioClip[2];
    #region PARTE COMUN
    private void Awake()
    {
        CargarPuntosControl();
    }
    void Start()
    {
        IniciarTemporizador();
        CargarDatos();
        CargarCooldowns(10, 15, 25, 60);
        esfera.transform.parent = null;
        StartCoroutine(ActualizarDistanciaPuntoControl());
        //CargarCamaras();
    }

    void Update()
    {
        if (vista.IsMine)
        {
            ActualizarTemporizador();
            
            RecogerInputMovimientoBasico();
            RecogerInputDerrape();
            int habilidad = RecogerInputHabilidades();
            if (habilidad != 5)
            {
                LanzarHabilidad(habilidad);
            }
            for (int i = 0; i < isCD.Length; i++)
            {
                if (isCD[i] == true)
                {
                    ReducirCoolDown(i);
                }
            }
            if (invencible == false) {
                body.GetComponent<MeshRenderer>().materials[1].SetColor("_Color", colorNormal);
            }
        }
    }

    private void FixedUpdate()
    {
        AplicarVelocidad();
        if (boosted == true)
        {
            esfera.AddForce(transform.forward * cantidadBoost);
            StartCoroutine(DesactivarBoost());
        }
        if (resbalado == true)
        {
            RecibirResbalar();
            StartCoroutine(DesactivarResbalado());
        }

    }

    private void LanzarHabilidad(int i)
    {
        if (timerCD[i] >= coolDowns[i])
        {
            isCD[i] = true;
            timerCD[i] = 0;
            switch (i)
            {
                case 0:
                    Habilidad0();
                    break;
                case 1:
                    Habilidad1();
                    break;
                case 2:
                    Habilidad2();
                    break;
                case 3:
                    Habilidad3();
                    break;
            }
        }
    }
    #endregion

    #region HABILIDADES
    public void Habilidad0()
    {
        this.GetComponent<AudioSource>().PlayOneShot(sonidos[0]);
        GameObject tronco = SoltarPrefab(prefab,transform.forward*6+new Vector3(0,0.5f,0));//TRONCO RODANTE
        tronco.GetComponent<TroncoRodante>().SetVector(transform.forward*50);
    }

    public void Habilidad1()
    {
        this.GetComponent<AudioSource>().PlayOneShot(sonidos[0]);
        SoltarPrefab(prefab2);//CAJA DE HERRAMIENTAS
    }

    public void Habilidad2()
    {
        this.GetComponent<AudioSource>().PlayOneShot(sonidos[0]);
        GameObject bomba = SoltarPrefab(prefab3,new Vector3(0,4,0));
        bomba.GetComponent<Bomba>().SetVector((transform.forward)*1000);
    }

    public void Habilidad3()
    {
        this.GetComponent<AudioSource>().PlayOneShot(sonidos[1]);
        invencible = true;
        body.GetComponent<MeshRenderer>().materials[1].SetColor("_Color", colorBoost);
        StartCoroutine(DesactivarInvencible(20));
    }

    #endregion
}