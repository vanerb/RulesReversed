using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLineRect : MonoBehaviour
{
   public float speed = 2.0f;
    public Vector3 direction; // Direcci�n del movimiento, puedes ajustarla en el Inspector

    private Vector3 originalPosition; // Posici�n original del objeto
    private bool movingToDestination = true; // Variable para controlar la direcci�n del movimiento

    private void Start()
    {
        originalPosition = transform.position; // Guardamos la posici�n original del objeto
    }

    private void Update()
    {
        float step = speed * Time.deltaTime;

        if (movingToDestination)
        {
            // Movimiento en la direcci�n especificada
            transform.position += direction * step;

            // Si se ha movido lo suficiente en la direcci�n, cambiamos la direcci�n
            if (Vector3.Distance(transform.position, originalPosition) >= direction.magnitude)
            {
                movingToDestination = false;
            }
        }
        else
        {
            // Movimiento de vuelta a la posici�n original
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, step);

            // Si ha vuelto a la posici�n original, cambiamos la direcci�n
            if (Vector3.Distance(transform.position, originalPosition) < 0.001f)
            {
                movingToDestination = true;
            }
        }
    }


  
}
