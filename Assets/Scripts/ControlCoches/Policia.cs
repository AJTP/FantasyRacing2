using UnityEngine;
using Photon.Pun;
using System.Collections;

public class Policia : Coche
{
    public GameObject prefab,prefab2;

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
        //#SONIDO ONESHOT SIRENAS
        boosted = true;
        cantidadBoost = 8000f;
    }

    public void Habilidad1()
    {
        GameObject misil = SoltarPrefab(prefab, (transform.forward * 6)+new Vector3(0,1,0));
        misil.GetComponent<Misil>().SetVector(-1*transform.forward * 100);
    }

    public void Habilidad2()
    {
        SoltarPrefab(prefab2);
    }

    public void Habilidad3()
    {
        StartCoroutine(Ultimate());   
    }

    public IEnumerator Ultimate() {
        for (int i = 0; i < 20; i++) {
            GameObject misil = SoltarPrefab(prefab, (transform.forward * 6) + new Vector3(0, 1, 0));
            misil.GetComponent<Misil>().SetVector(-1 * transform.forward * 100);
            yield return new WaitForSeconds(0.1f);
        }
    }
    #endregion
}