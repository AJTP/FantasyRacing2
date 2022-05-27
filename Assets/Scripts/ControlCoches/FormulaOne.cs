using UnityEngine;
using Photon.Pun;
using System.Collections;

public class FormulaOne : Coche
{
    public GameObject prefab;
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
            //
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
        stuneado = false;
        ralentizado = false;
        resbalado = false;
        panelGas.SetActive(false);
    }

    public void Habilidad1()
    {
        StartCoroutine(RastroFuego());
    }

    public void Habilidad2()
    {
        //#SONIDO ONESHOT BOOST
        aceleracion += 1;
    }

    public void Habilidad3()
    {
        //#SONIDO ONESHOT FORMULA UNO
        RecibirBoost(30000);
        //boosted = true;
        //cantidadBoost = 30000f;
    }


    public IEnumerator RastroFuego()
    {
        for (int i = 0; i < 20; i++)
        {
            SoltarPrefab(prefab,new Vector3(0,1.2f,0));
            yield return new WaitForSeconds(0.125f);
        }
    }
    #endregion
}