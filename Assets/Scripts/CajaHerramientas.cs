using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CajaHerramientas : Prop
{
    private void Start()
    {
        StartCoroutine(MuerteProp());
    }
}
