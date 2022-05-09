using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Ambulancia : Coche
{
    private bool boosted = false;
    private float cantidadBoost = 0;
    private GameObject canvas;
    #region PREFABS
    public GameObject charcoSangre;
    #endregion
    void Start()
    {
        view = GetComponent<PhotonView>();
        camarillas.transform.parent = null;
        esfera.transform.parent = null;
        //CARGAR COOLDOWNS DESDE ALGUN SITIO
        coolDowns[0] = 4;
        coolDowns[1] = 8;
        coolDowns[2] = 12;
        coolDowns[3] = 16;
        for(int i=0;i<timerCD.Length;i++) {
            timerCD[i] = coolDowns[i];
        }
        //CARGAR IMAGENES
        
    }

    void Update()
    {
        if (view.IsMine) {
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
            Debug.Log("entra");
            esfera.AddForce(transform.forward * cantidadBoost);
            //boosted = false;
        }
    }

    private int RecogerInputHabilidades()
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

    private void ReducirCoolDown(int i) {
            if (timerCD[i] < coolDowns[i])
            {
                imagenes[i].color = Color.red;
                timerCD[i] += Time.deltaTime;
                imagenes[i].fillAmount = timerCD[i] / coolDowns[i];
            }
            else if(timerCD[i]>= coolDowns[i]) {
                imagenes[i].color = Color.cyan;
                timerCD[i] = coolDowns[i];
                imagenes[i].fillAmount = 1;
                isCD[i] = false;
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

    private void Habilidad0(){
        //USA LAS SIRENAS Y AUMENTA SU VELOCIDAD
        print("HABILIDA 0 LANZADA");
        //Activar Sirenas durante la duración de la habilidad
        //Recibir Boost de velocidad
        boosted = true;
        cantidadBoost = 20000f;
    }

    private void Habilidad1(){
        // Deja en el suelo un charco de sangre que resbala
        print("HABILIDA 1 LANZADA");
        //Soltar prefab
        SoltarPrefab(charcoSangre);
    }

    private void Habilidad2(){
        //REGENERA SU VIDA UN 30%
        print("HABILIDA 2 LANZADA");
        // Sumar un % de vida
        vida += vidaMaxima / 3;
        if (vida > vidaMaxima)
            vida = vidaMaxima;
        //Animacion suma vida
    }

    private void Habilidad3(){
        //ELECTROCUTA AL RETO DE JUGADORES Y LOS DEJA INMOVILIZADOS
        print("HABILIDA 3 LANZADA");
        //Animación electricidad
        //Aplica Stun al resto de jugadores
        //Animación electricidad en el jugador que recibe el stun
    }
}