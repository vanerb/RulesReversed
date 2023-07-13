using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject panelPausa;
    private bool estaPausado;

    private void Start()
    {
        // Asegurarse de que el juego comience sin estar pausado
        estaPausado = false;
        panelPausa.SetActive(false);
    }

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Joystick1Button7))
        {
            // Si se presiona la tecla Escape, alternar la pausa
            if (estaPausado)
                ReanudarJuego();
            else
                PausarJuego();
        }

    }

    public void PausarJuego()
    {
        // Pausar el juego y mostrar el panel de pausa
        Time.timeScale = 0f;
        estaPausado = true;
        panelPausa.SetActive(true);
    }

    public void ReanudarJuego()
    {
        // Reanudar el juego y ocultar el panel de pausa
        if (!HablidadLenta.isActive)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0.5f;
        }
        
        estaPausado = false;
        panelPausa.SetActive(false);
    }
}
