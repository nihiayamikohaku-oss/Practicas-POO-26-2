using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class Score : MonoBehaviour
{

    public TextMeshProUGUI textoPuntaje;

    private int puntajeActual = 0;
    public int PuntajeActual { get; set; }
    
        void Start()
        {

            textoPuntaje.text = "Puntos" + PuntajeActual;
            
        }

    private void Update()
    {
        textoPuntaje.text = "Puntos" + PuntajeActual;
    }

    public void CalcularPuntaje()
        {
            int puntaje = 0;


        puntaje++;

        PuntajeActual = puntaje;

            if (textoPuntaje != null) textoPuntaje.text = "Puntos: " + PuntajeActual;
        }
    }
