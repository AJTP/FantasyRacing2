using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ambulancia : Coche
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //USA LAS SIRENAS Y AUMENTA SU VELOCIDAD
    private void Habilidad1(){
        //Activar Sirenas durante la duración de la habilidad

        //Recibir Boost de velocidad
        RecibirBoost(1f);
    }
    // Deja en el suelo un charco de sangre que resbala
    private void Habilidad2(){
        //Soltar prefab
        SoltarPrefab();
    }
    //REGENERA SU VIDA UN 30%
    private void Habilidad3(){
        // Sumar un % de vida
        vida+=vidaMaxima/3;
        if(vida>vidaMaxima)
            vida = vidaMaxima;

        //Animacion suma vida
    }

    //ELECTROCUTA AL RETO DE JUGADORES Y LOS DEJA INMOVILIZADOS
    private void Habilidad4(){
        //Animación electricidad
        //Aplica Stun al resto de jugadores
        //Animación electricidad en el jugador que recibe el stun
    }
}
