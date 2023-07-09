
using UnityEngine;

public class MenuNavigation : MonoBehaviour
{
    public float sensitivity = 1f;
    private bool isUsingGamepad;

    private void Start()
    {
        isUsingGamepad = false;
    }
    void Update()
    {

        if (Input.GetJoystickNames().Length > 0)
        {
            isUsingGamepad = true;
        }
        // Si el movimiento es detectado por el teclado/ratón, se establece el modo de teclado/ratón
        else
        {
            isUsingGamepad = false;
        }

        if (isUsingGamepad)
        {
            // Obtener los movimientos del mando
            float horizontal = Input.GetAxis("Horizontal"); // Eje horizontal del mando
            float vertical = Input.GetAxis("Vertical"); // Eje vertical del mando

            // Mover el ratón
            Vector3 mouseMovement = new Vector3(horizontal, vertical, 0) * sensitivity;
            Vector3 newPosition = Input.mousePosition + mouseMovement;
            Cursor.visible = false;
            newPosition.z = Camera.main.transform.position.z;
            Vector3 newWorldPosition = Camera.main.ScreenToWorldPoint(newPosition);
            Cursor.lockState = CursorLockMode.Confined;
            newWorldPosition.z = 0f;
            Cursor.visible = false;
            transform.position = newWorldPosition;

        }
        else
        {

        }
    }

}
