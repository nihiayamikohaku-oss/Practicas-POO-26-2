using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sensor : MonoBehaviour


{
    public GameObject[] Luces;

    public Score Score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

        //Ahora vas a buscar por tipo de componente heredado en lugar de buscar por etiqueta

        Item itemRecogido = other.GetComponent<Item>();



        if (itemRecogido != null) 
        {
            itemRecogido.Recoger();
        }


     if (other.CompareTag("Arcade"))
        {
           // Luz.SetActive(true); un objeto individual

           foreach (var Luz in Luces)
            {
                Luz.SetActive(true); //dentro del bucle aplica a todos los objetos del grupo
            }
            Debug.Log("Hecha una ficha");
        }
     if (other.CompareTag("item"))
        {
            Score.CalcularPuntaje();
            other.gameObject.SetActive(false);
            Debug.Log("Obtuviste un PejeCoin");
        }
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Arcade"))
        {
            //Luz.SetActive(false); un objeto
            foreach (var Luz in Luces)
            {
                Luz.SetActive(false); //dentro del bucle aplica a todos los objetos del grupo
            }
            Debug.Log("Game Over: regresa cuando quieras");
        }

    }



}//no
