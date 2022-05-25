using UnityEngine;
using Photon.Pun;
using System.Collections;

public class CamionBasura : Coche
{
    public GameObject prefab,prefab2;
    public bool aplastador = false;
    #region PARTE COMUN

    private void Awake()
    {
        CargarPuntosControl();
    }
    void Start()
    {
        CargarDatos();
        CargarCooldowns(4, 8, 12, 20);
        esfera.transform.parent = null;
        StartCoroutine(ActualizarDistanciaPuntoControl());
        //CargarCamaras();
    }

    void Update()
    {
        if (vista.IsMine)
        {
            RecogerInputMovimientoBasico();
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
        SoltarPrefab(prefab);
    }

    public void Habilidad1()
    {
        //#ESTETICO SE PONE EL ESCUDO
        protegido = true;
    }

    public void Habilidad2()
    {
        SoltarPrefab(prefab2,new Vector3(0,1.5f,0));
    }

    public void Habilidad3()
    {
        ModificarSize(2,10,true);
        aplastador = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (aplastador && collision.other.CompareTag("Coche")) {
            collision.other.GetComponent<Coche>().ModificarSize(0.5f, 3, false);
        }        
    }

    #endregion
    public IEnumerator DesactivarAplastador(int tiempo)
    {
        yield return new WaitForSeconds(tiempo);
        aplastador = false;
    }
}
