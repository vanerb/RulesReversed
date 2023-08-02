using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCircular : MonoBehaviour
{
    public float speed = 2.0f; // Velocidad del movimiento circular, puedes ajustarla en el Inspector
    public float radius = 2.0f; // Radio del círculo, puedes ajustarla en el Inspector

    private LineRenderer lineRenderer;
    private Vector3 center; // Centro del círculo
    private float angle = 0f; // Ángulo inicial

    private void Start()
    {
        center = transform.position; // Guardamos la posición inicial del objeto como el centro del círculo
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, center);
    }

    private void Update()
    {
        // Calculamos la posición en el círculo en función del tiempo y el radio
        angle += speed * Time.deltaTime;
        float x = center.x + Mathf.Cos(angle) * radius;
        float y = center.y + Mathf.Sin(angle) * radius;

        // Actualizamos la posición del objeto para que se mueva de forma circular
        transform.position = new Vector3(x, y, transform.position.z);

        // Actualizamos el punto final de la cadena (Line Renderer) para que vaya desde el centro hasta el final del radio
        lineRenderer.SetPosition(1, new Vector3(x, y, transform.position.z));
    }
}
