using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GampadController : MonoBehaviour
{
    public Button[] menuButtons; // Array de botones del menú principal

    private int currentIndex = 0; // Índice del botón actualmente seleccionado
    private bool isAxisInUse = false; // Bandera para evitar múltiples cambios de selección con un solo movimiento de eje

    private void Start()
    {
        // Obtener referencias a los botones del menú principal
        menuButtons = GetComponentsInChildren<Button>();
        // Inicializar el primer botón como seleccionado
        SelectButton(0);
    }

    private void Update()
    {
        // Obtener el valor del eje vertical del mando
        float verticalInput = Input.GetAxis("Vertical");

        // Si el valor del eje vertical es positivo, mover hacia arriba en el menú
        if (verticalInput > 0 && !isAxisInUse)
        {
            SelectButton(currentIndex - 1);
            isAxisInUse = true;
        }
        // Si el valor del eje vertical es negativo, mover hacia abajo en el menú
        else if (verticalInput < 0 && !isAxisInUse)
        {
            SelectButton(currentIndex + 1);
            isAxisInUse = true;
        }
        // Si el valor del eje vertical es cero, permitir otro cambio de selección
        else if (verticalInput == 0)
        {
            isAxisInUse = false;
        }

        // Si se pulsa el botón correspondiente en el mando, activar el botón seleccionado
        if (Input.GetButtonDown("Submit"))
        {
            ActivateButton();
        }
    }

    private void SelectButton(int index)
    {
        // Asegurarse de que el índice esté dentro de los límites del array
        if (index < 0)
        {
            index = menuButtons.Length - 1;
        }
        else if (index >= menuButtons.Length)
        {
            index = 0;
        }

        // Desactivar la selección del botón anteriormente seleccionado
        menuButtons[currentIndex].GetComponent<Image>().color = Color.white;

        // Activar la selección en el nuevo botón
        currentIndex = index;
        menuButtons[currentIndex].GetComponent<Image>().color = Color.yellow;
    }

    private void ActivateButton()
    {
        // Simular un clic en el botón seleccionado
        menuButtons[currentIndex].onClick.Invoke();
    }
}
