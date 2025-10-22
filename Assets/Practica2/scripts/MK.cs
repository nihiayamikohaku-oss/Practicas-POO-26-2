using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MK : Item
{
    public override void Recoger()
    {
        score.PuntajeActual += 10;
        Debug.Log("Nombre de Arcade" + nombreItem + "Año de sañida: 1992");
        Destroy(gameObject);
    }
}
