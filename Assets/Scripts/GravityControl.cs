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
    public GameObject cameraObject;
   
    public float gravityScalePos = 1;
    public float gravityScaleNeg = -1;
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
            if (Input.GetKeyDown(KeyCode.C) && !notTouch || Input.GetKeyDown(KeyCode.JoystickButton2) && !notTouch)
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
            cameraObject.transform.SetParent(player2.transform);
            cameraObject.transform.position = new Vector3(player2.transform.position.x, player2.transform.position.y, -10);
            //player2.GetComponent<SecondCharacter>().velocidad = 0;
            //player1.GetComponent<PlayerController>().velocidad = 5;
        }
        else
        {
            // Cambiar la gravedad cuando se pulsa un botón (puedes cambiar "Jump" por el nombre del botón que deseas)
            if (Input.GetKeyDown(KeyCode.C) && !notTouch || Input.GetKeyDown(KeyCode.JoystickButton2) && !notTouch)
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
            cameraObject.transform.SetParent(player1.transform);
            cameraObject.transform.position = new Vector3(player1.transform.position.x, player1.transform.position.y, -10);            
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
                player1.GetComponent<Rigidbody2D>().gravityScale = gravityScalePos;
            }
            else
            {
                player1.GetComponent<Rigidbody2D>().gravityScale =gravityScaleNeg;
            }
        }
        else
        {
            if (isGravityReversed)
            {
                player2.GetComponent<Rigidbody2D>().gravityScale = gravityScalePos;
            }
            else
            {
                player2.GetComponent<Rigidbody2D>().gravityScale = gravityScaleNeg;
            }
        }

    }

  


}
