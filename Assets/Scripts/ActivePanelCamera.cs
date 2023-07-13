using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivePanelCamera : MonoBehaviour
{

    private bool estaActivado;
    public GameObject GUI;
    private void Start()
    {
        // Asegurarse de que el juego comience sin estar pausado
        estaActivado = false;
        GUI.SetActive(false);
    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetKeyDown(KeyCode.Joystick1Button6))
        {
            // Si se presiona la tecla Escape, alternar la pausa
            if (estaActivado)
                ReanudarJuego();
            else
                PausarJuego();
        }

    }

    public void PausarJuego()
    {
      
        estaActivado = true;
        GUI.SetActive(true);
    }

    public void ReanudarJuego()
    {
        estaActivado = false;
        GUI.SetActive(false);
    }
}
