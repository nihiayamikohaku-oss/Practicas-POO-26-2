using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform Bola;

   // Transform position x   y   z 0

    public Vector3 offset = new Vector3(0f, 3f, -6f);

    private bool seguir = false;
    void LateUpdate()
    {

        if (seguir && Bola != null)
        {
            transform.position = Bola.position + offset;
         
        }
    }

    public void IniciarSeguimiento()
    {
        seguir = true;
    }

    public void DetenerSeguimiento()
    {
        seguir = false;
    }
}
