using UnityEngine;
using Photon.Pun;
using System.Collections;

public class CamionBasura : Coche
{
    public GameObject prefab,prefab2,prefab3;
    public GameObject escudo;
    public AudioClip[] sonidos = new AudioClip[4];
    #region PARTE COMUN

    private void Awake()
    {
        CargarPuntosControl();
    }
    void Start()
    {
        IniciarTemporizador();
        CargarDatos();
        CargarCooldowns(15, 25, 30, 40);
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
            if (protegido == false) {
                escudo.SetActive(false);
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
        SoltarPrefab(prefab);
    }

    public void Habilidad1()
    {
        //#ESTETICO SE PONE EL ESCUDO
        this.GetComponent<AudioSource>().PlayOneShot(sonidos[1]);
        escudo.SetActive(true);
        protegido = true;
    }

    public void Habilidad2()
    {
        this.GetComponent<AudioSource>().PlayOneShot(sonidos[2]);
        SoltarPrefab(prefab2,new Vector3(0,1.5f,0));
    }

    public void Habilidad3()
    {
        this.GetComponent<AudioSource>().PlayOneShot(sonidos[3]);
        SoltarPrefab(prefab3,new Vector3(0,1,0));
    }

    #endregion
}
