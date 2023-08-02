using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLineRect : MonoBehaviour
{
   public float speed = 2.0f;
    public Vector3 direction; // Dirección del movimiento, puedes ajustarla en el Inspector

    private Vector3 originalPosition; // Posición original del objeto
    private bool movingToDestination = true; // Variable para controlar la dirección del movimiento

    private void Start()
    {
        originalPosition = transform.position; // Guardamos la posición original del objeto
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        if (movingToDestination)
        {
            // Movimiento en la dirección especificada
            transform.position += direction * step;

            // Si se ha movido lo suficiente en la dirección, cambiamos la dirección
            if (Vector3.Distance(transform.position, originalPosition) >= direction.magnitude)
            {
                movingToDestination = false;
            }
        }
        else
        {
            // Movimiento de vuelta a la posición original
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, step);

            // Si ha vuelto a la posición original, cambiamos la dirección
            if (Vector3.Distance(transform.position, originalPosition) < 0.001f)
            {
                movingToDestination = true;
            }
        }
    }


  
}
