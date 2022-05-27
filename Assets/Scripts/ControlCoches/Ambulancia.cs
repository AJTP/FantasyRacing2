using UnityEngine;
using Photon.Pun;

public class Ambulancia : Coche
{
    public GameObject prefab,prefab2;
    public AudioClip[] sonidos = new AudioClip[4];
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
        this.GetComponent<AudioSource>().PlayOneShot(sonidos[0]);
        RecibirBoost(8000);
    }

    public void Habilidad1(){
        //#SONIDO ONESHOT MASA VISCOSA
        this.GetComponent<AudioSource>().PlayOneShot(sonidos[1]);
        SoltarPrefab(prefab); 
    }

    public void Habilidad2(){
        //#SONIDO SANACIÓN
        this.GetComponent<AudioSource>().PlayOneShot(sonidos[2]);
        ActualizarHP(maxHP / 3);
    }

    public void Habilidad3(){
        this.GetComponent<AudioSource>().PlayOneShot(sonidos[3]);
        protegido = true;
        SoltarPrefab(prefab2);
    }

    #endregion
}