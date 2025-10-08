using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreMannager : MonoBehaviour
{
   
    public Text textoPuntaje;
    
    private int puntajeActual = 0;

    [SerializeField]
    private Pin[] pinos;
    void Start()
    {

        textoPuntaje.text = "Tienes un millon de dolares";
        pinos = FindObjectsOfType<Pin>();
    }

  
    public void CalcularPuntaje()
      {
          int puntaje = 0;

          foreach (Pin pin in pinos)
          {
            if (pin.EstaCaido()) { puntaje++; }
          }

          puntajeActual = puntaje;

        if (textoPuntaje != null) textoPuntaje.text = "Puntos: " + puntajeActual;
      }
}
