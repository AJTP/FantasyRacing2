using UnityEngine;
using Photon.Pun;

public class Ambulancia : Coche
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
        CargarCooldowns(4,8,12,20);
        esfera.transform.parent = null;
        StartCoroutine(ActualizarDistanciaPuntoControl());
        //CargarCamaras();
    }

    void Update()
    {
        if (vista.IsMine) {
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
        if (boosted == true) {
            esfera.AddForce(transform.forward * cantidadBoost);
            StartCoroutine(DesactivarBoost());
        }
        if (resbalado == true)
        {
            RecibirResbalar();
            StartCoroutine(DesactivarResbalado());
        }
    }

    private void LanzarHabilidad(int i) {
        if (timerCD[i] >= coolDowns[i])
        {
            isCD[i] = true;
            timerCD[i] = 0;
            switch (i) {
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
    public void Habilidad0(){
        //#SONIDO ONESHOT SIRENAS
        boosted = true;
        cantidadBoost = 8000f;
    }

    public void Habilidad1(){
       SoltarPrefab(prefab); 
    }

    public void Habilidad2(){
        ActualizarHP(maxHP / 3);
    }

    public void Habilidad3(){
        print("HABILIDA 3 LANZADA");
        //ELECTROCUTA AL RESTO DE JUGADORES
    }

    #endregion
}