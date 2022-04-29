using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    #region VARIABLES PUBLICAS
    public Transform kartT;
    public Rigidbody esfera;
    public List<ParticleSystem> particulasDerrape = new List<ParticleSystem>();
    public List<ParticleSystem> particulasImpulso = new List<ParticleSystem>();


    float velocidad, velocidadActual;
    float rotacion, rotacionActual;
    int direccionDerrape;
    float fuerzaDerrape;
    int modoDerrape;
    bool primero,segundo,tercero;

    Color color;
    //BOOLEANOS
    public bool derrapando;
    //PARAMETROS
    public float aceleracion = 30f;
    public float direccion = 80f;
    public float gravedd = 10f;

    public LayerMask layerMask;

    //PARTE DEL MODELO
    public Transform ruedasDelanteras,ruedasTraseras;
    public Transform particulasRuedas, particulasTurbo;
    public Color[] tuboColores;
    private 

    #endregion
    // Start is called before the first frame update
    void Start()
    {
        // for (int i = 0; i < particulasRuedas.GetChild(0).childCount; i++)
        // {
        //     particulasDerrape.Add(particulasRuedas.GetChild(0).GetChild(i).GetComponent<ParticleSystem>());
        // }

        // for (int i = 0; i < wheelParticles.GetChild(1).childCount; i++)
        // {
        //     primaryParticles.Add(wheelParticles.GetChild(1).GetChild(i).GetComponent<ParticleSystem>());
        // }

        // foreach(ParticleSystem p in flashParticles.GetComponentsInChildren<ParticleSystem>())
        // {
        //     secondaryParticles.Add(p);
            
        // }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
