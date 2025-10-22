using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hollow : Item
{
    public override void Recoger()
    {
        score.PuntajeActual += 12;
        Debug.Log("Nombre de Arcade" + nombreItem + "Año de sañida: 2005" + "Dificultad: Alta");
    }
}
