using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlBola : MonoBehaviour
{
    public Transform CamaraPrincipal;

    public Rigidbody rb;

    public float velocidadDeApuntado = 5f;
    public float limiteDerecho = 2;
    public float limiteIzquierdo = -2;
    public float fuerzaDeLanzamiento = 10000f;

    public CameraFollow cameraFollow;
   public ScoreMannager scoreManager;

    private bool haSidoLanzada = false;
 
   
    void Start()
    {

        rb = GetComponent<Rigidbody>();


    }

    // Update is called once per frame
    void Update()
    {//Expresion: mientras haSidoLanzada
        if (haSidoLanzada == false)
        {

            Apuntar();
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Lanzar();
            }
        }
    }

    void Apuntar()
    {
        /*1. Leer un input horizontal de tipo axis te permite registrar
         entradas con las teclas A y D, y flecha izquierda y flecha derecha*/
        float inputHorizontal = Input.GetAxis("Horizontal");

        /*2.mover la bola hacia los lados*/
        transform.Translate(Vector3.right * inputHorizontal * velocidadDeApuntado * Time.deltaTime);

        /*3. Delimitar el movimiento de la bola*/
        Vector3 posicionActual = transform.position;

        posicionActual.x = Mathf.Clamp(posicionActual.x, limiteIzquierdo, limiteDerecho);

        transform.position = posicionActual;
    }


 

    void Lanzar()
    {
        haSidoLanzada = true;
        rb.AddForce(Vector3.forward * fuerzaDeLanzamiento);



        if (cameraFollow != null) cameraFollow.IniciarSeguimiento();
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Pin"))
        {
            if (cameraFollow != null) cameraFollow.DetenerSeguimiento();

            if (scoreManager != null) Invoke("CalcularPuntaje", 0f);
        }
    }

    void CalcularPuntaje()
    {
        scoreManager.CalcularPuntaje();
    }

}






//BIENVENIDO A LA ENTRADA AL INFIERNO
