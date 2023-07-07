using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckGround : MonoBehaviour
{
    public bool puedeSaltar = false; // Indica si el personaje puede saltar en un momento dado


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelo"))
        {
            puedeSaltar = true;
        }
    }


    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Suelo"))
        {
            puedeSaltar = false;
        }
    }
}
