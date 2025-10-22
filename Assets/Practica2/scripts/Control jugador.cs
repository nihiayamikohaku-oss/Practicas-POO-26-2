using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controljugador : MonoBehaviour
{
    //Movimiento
    
    public float velocidad = 5f; //es para indicarf la velocidad del jugador
    public float gravedad = -9.8f; //es para controlar la velocidad/fuerza de gravedad hacia el jugador

    private CharacterController controller; //nos permite el registro de movimiento en el juego 
    private Vector3 velocidadVertical; //nos va a permitir saber que tan rápido caemos


    //Variables Vista

    public Transform camara; //registra que camara en este ejercicio va a funcionar como los ojos del jugador
    public float sensibilidadMouse = 200f; //velocidad de movimiento del mouse(como camara) para rotar la vista
    private float rotacionXVertical = 0f; //


    void Start()
    {
        controller = GetComponent<CharacterController>();
        //esta invocacion busca el componente character controler
        Cursor.lockState = CursorLockMode.Locked;
        //esta linea bloquea el puntero del mouse en los limites de la pantalla
    }

    // Update is called once per frame
    void Update()
    {
        ManejadorVista();
        ManejadorMovimiento();

    }

    void ManejadorVista()
    {
        //1.Leer el input del mouse
        float mouseX= Input.GetAxis("Mouse X") * sensibilidadMouse *Time.deltaTime;
        //Registra el desplazamiento del mouse sobre el eje horizontal
        float mouseY = Input.GetAxis("Mouse Y") * sensibilidadMouse * Time.deltaTime;
        //Registra el desplazamiento del mouse sobre el eje Vertical


        //2.Construir la rotacion horizontal
        transform.Rotate(Vector3.up * mouseX); // Para conocer si rotara de la cabeza


        //3.Registro de la rotacion vertical
        rotacionXVertical -= mouseY;


        //4.Limitar rotacion vertical
        Mathf.Clamp(rotacionXVertical, -90f, 90f); //Es para que encuentre en un angulo recto
        //Se tarta la rotacion del cuerpo


        //5.Aplicar la rotacion

                            // son los ejes           x           y   z
        camara.localRotation = Quaternion.Euler(rotacionXVertical, 0, 0); //se trata de la rotacion de la vista 
    }


    void ManejadorMovimiento()
    {
        //1. leer el input de movimiento(WASD/flechas de direccion)

        float inputX = Input.GetAxis("Horizontal");
        float inputZ = Input.GetAxis("Vertical");

        //2. Crear el Vector de movimiento
        //Se almacena de forma local el registro de direccion de movimiento
        Vector3 direccion = transform.right * inputX + transform.forward * inputZ;
        //Es el registro de la direccion en la cual se va a mover el personaje: A y D derecha/izquierda

        //3. Mover el caracter controler
        controller.Move(direccion*Time.deltaTime); // Define la velocidad del desplazamineto

        //4. Aplicar la gravedad
        //Registro si estoy en el piso para un futuro compotamiento (salto)
        if(controller.isGrounded && velocidadVertical.y <0)
        {
            velocidadVertical.y = -9.8f; //Una pequeña fuerza hacia abajo para mantenerlo en el piso
        }

        velocidadVertical.y += Time.deltaTime;

        controller.Move(velocidadVertical * Time.deltaTime); //Registra la velocidad de caida      
    }
}
