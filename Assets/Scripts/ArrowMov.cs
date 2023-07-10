using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMov : MonoBehaviour
{
    public float amplitud;
    public float velocidad;
    private Vector3 posiciónInicial;
    // Start is called before the first frame update
    void Start()
    {
        posiciónInicial = transform.position;
    }

    void Update()
    {
        float desplazamientoY = Mathf.Sin(Time.time * velocidad) * amplitud;
        transform.position = posiciónInicial + new Vector3(0f, desplazamientoY, 0f);
    }
}
