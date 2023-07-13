using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GampadController : MonoBehaviour
{
    public Button[] menuButtons; // Array de botones del men� principal

    private int currentIndex = 0; // �ndice del bot�n actualmente seleccionado
    private bool isAxisInUse = false; // Bandera para evitar m�ltiples cambios de selecci�n con un solo movimiento de eje

    private void Start()
    {
        // Obtener referencias a los botones del men� principal
        menuButtons = GetComponentsInChildren<Button>();
        // Inicializar el primer bot�n como seleccionado
        SelectButton(0);
    }

    private void Update()
    {
        // Obtener el valor del eje vertical del mando
        float verticalInput = Input.GetAxis("Vertical");

        // Si el valor del eje vertical es positivo, mover hacia arriba en el men�
        if (verticalInput > 0 && !isAxisInUse)
        {
            SelectButton(currentIndex - 1);
            isAxisInUse = true;
        }
        // Si el valor del eje vertical es negativo, mover hacia abajo en el men�
        else if (verticalInput < 0 && !isAxisInUse)
        {
            SelectButton(currentIndex + 1);
            isAxisInUse = true;
        }
        // Si el valor del eje vertical es cero, permitir otro cambio de selecci�n
        else if (verticalInput == 0)
        {
            isAxisInUse = false;
        }

        // Si se pulsa el bot�n correspondiente en el mando, activar el bot�n seleccionado
        if (Input.GetButtonDown("Submit"))
        {
            ActivateButton();
        }
    }

    private void SelectButton(int index)
    {
        // Asegurarse de que el �ndice est� dentro de los l�mites del array
        if (index < 0)
        {
            index = menuButtons.Length - 1;
        }
        else if (index >= menuButtons.Length)
        {
            index = 0;
        }

        // Desactivar la selecci�n del bot�n anteriormente seleccionado
        menuButtons[currentIndex].GetComponent<Image>().color = Color.white;

        // Activar la selecci�n en el nuevo bot�n
        currentIndex = index;
        menuButtons[currentIndex].GetComponent<Image>().color = Color.yellow;
    }

    private void ActivateButton()
    {
        // Simular un clic en el bot�n seleccionado
        menuButtons[currentIndex].onClick.Invoke();
    }
}
