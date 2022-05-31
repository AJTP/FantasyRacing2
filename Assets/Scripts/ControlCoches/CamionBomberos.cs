using UnityEngine;
using Photon.Pun;
using System.Collections;

public class CamionBomberos : Coche
{
    public GameObject prefab,prefab2,prefab3;
    public AudioClip[] sonidos = new AudioClip[3];
    #region PARTE COMUN
    private void Awake()
    {
        CargarPuntosControl();
    }
    void Start()
    {
        CargarDatos();
        CargarCooldowns(8, 15, 20, 50);
        esfera.transform.parent = null;
        StartCoroutine(ActualizarDistanciaPuntoControl());
        //CargarCamaras();
    }

    void Update()
    {
        if (vista.IsMine)
        {
            //
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
        //#SONIDO ONESHOT SIRENAS
        RecibirBoost(8000);
        //boosted = true;
        //cantidadBoost = 8000f;
    }

    public void Habilidad1()
    {
       
        StartCoroutine(RastroAgua());
    }

    public void Habilidad2()
    {
        this.GetComponent<AudioSource>().PlayOneShot(sonidos[2]);
        GameObject bomba = SoltarPrefab(prefab3, new Vector3(0, 4, 0));
        bomba.GetComponent<BombaAgua>().SetVector((transform.forward) * 1000);
    }

    public void Habilidad3()
    {
        GameObject ob = SoltarPrefab(prefab2);
        protegido = true;
        ob.GetComponent<FuegoRotatorio>().SetParent(this.puntoRayoSuelo.transform);
    }

    public IEnumerator RastroAgua() {
        for (int i = 0; i < 10; i++) {
            this.GetComponent<AudioSource>().PlayOneShot(sonidos[1]);
            SoltarPrefab(prefab);
            yield return new WaitForSeconds(0.25f);
        }        
    }
    #endregion
}