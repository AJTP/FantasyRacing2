using UnityEngine;
using Photon.Pun;

public class Pickup : Coche
{
    public GameObject prefab, prefab2;

    private void Awake()
    {
        CargarPuntosControl();
    }
    void Start()
    {
        CargarVista();
        CargarCooldowns(4, 8, 12, 20);
        esfera.transform.parent = null;
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

    #region HABILIDADES
    public void Habilidad0()
    {
        print("HABILIDA 0 LANZADA");
        SoltarPrefab(prefab);//TRONCO RODANTE
    }

    public void Habilidad1()
    {
        print("HABILIDA 1 LANZADA");
        SoltarPrefab(prefab2);//CAJA DE HERRAMIENTAS
    }

    public void Habilidad2()
    {
        print("HABILIDA 2 LANZADA");
        //CATAPULTA UNA BOMBA QUE EXPLOTA AL TOCAR EL SUELO
    }

    public void Habilidad3()
    {
        print("HABILIDA 3 LANZADA");
        //ACTIVA EL 4X4, NO LE AFECTAN LOS EFECTOS NEGATIVOS NI CUALQUIER TIPO DE TERRENO
    }

    #endregion
}