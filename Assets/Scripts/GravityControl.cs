using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GravityControl : MonoBehaviour
{
    public float gravity = 9.8f; // Valor de gravedad normal
    public bool isGravityReversed = true; // Variable para rastrear si la gravedad está invertida
    private CheckGround checkGround;
    private bool notTouch = false;



    public GameObject player1;
    public GameObject player2;
    public PlayerSwitch playerSwitch;

    public CinemachineVirtualCamera virtualCamera;

    public 

    void Start()
    {
        isGravityReversed = true;
        checkGround = GetComponentInChildren<CheckGround>();
        notTouch = false;
    }

    void Update()
    {

        if (playerSwitch.isActive)
        {

            // Cambiar la gravedad cuando se pulsa un botón (puedes cambiar "Jump" por el nombre del botón que deseas)
            if (Input.GetKeyDown(KeyCode.C) && !notTouch)
            {
                FindObjectOfType<AudioManager>().Play("Gravedad");
                if (isGravityReversed)
                {
                    player1.transform.Rotate(0, 0, 180);
                    isGravityReversed = false;
                }
                else
                {
                    player1.transform.Rotate(0, 0, 180);
                    isGravityReversed = true;
                }
                //isGravityReversed = !isGravityReversed;
                ChangeGravity();

            }

            CompruebaSuelo();
            player2.GetComponent<GravityControl>().enabled = false;
            player1.GetComponent<GravityControl>().enabled = true;
            virtualCamera.Follow = player1.transform;
            virtualCamera.LookAt = player1.transform;
            //player2.GetComponent<SecondCharacter>().velocidad = 0;
            //player1.GetComponent<PlayerController>().velocidad = 5;
        }
        else
        {
            // Cambiar la gravedad cuando se pulsa un botón (puedes cambiar "Jump" por el nombre del botón que deseas)
            if (Input.GetKeyDown(KeyCode.C) && !notTouch)
            {
                FindObjectOfType<AudioManager>().Play("Gravedad");
                if (isGravityReversed)
                {
                    player2.transform.Rotate(0, 0, 180);
                    isGravityReversed = false;
                }
                else
                {
                    player2.transform.Rotate(0, 0, 180);
                    isGravityReversed = true;
                }
                //isGravityReversed = !isGravityReversed;
                ChangeGravity();

            }

            CompruebaSuelo();
            player1.GetComponent<GravityControl>().enabled = false;
            player2.GetComponent<GravityControl>().enabled = true;
            virtualCamera.Follow = player2.transform;
            virtualCamera.LookAt = player2.transform;
            //player1.GetComponent<PlayerController>().velocidad = 0;
            //player2.GetComponent<SecondCharacter>().velocidad = 5;
        }

       

      
    }

    void CompruebaSuelo()
    {
        if (!checkGround.puedeSaltar)
        {
            notTouch = true;
        }
        else
        {
            notTouch = false;
        }
    }
  
    void ChangeGravity()
    {
        if (playerSwitch.isActive)
        {
            if (isGravityReversed)
            {
                player1.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
            else
            {
                player1.GetComponent<Rigidbody2D>().gravityScale = -1;
            }
        }
        else
        {
            if (isGravityReversed)
            {
                player2.GetComponent<Rigidbody2D>().gravityScale = 1;
            }
            else
            {
                player2.GetComponent<Rigidbody2D>().gravityScale = -1;
            }
        }

    }

  


}
