using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondCharacter : MonoBehaviour
{
    public Rigidbody2D rb;
    public PlayerController jugador;
    public float velocidad = 3;
    public CheckGround checkGround;
    public float fuerzaSalto = 5f; // Fuerza de salto del personaje
    public GravityControl gravity;
    public Animator anim;

    public PlayerSwitch playerSwitch;
    public Vector2 lastJumpPoint;

    public float coyoteTime = 0.1f; // Tiempo en segundos que dura el Coyote Time.
    private float coyoteTimeCounter; // Contador interno para el tiempo restante.
    private void Start()
    {
        anim = GetComponent<Animator>();
        lastJumpPoint = transform.position;

    }

    private void Update()
    {

        if (checkGround.puedeSaltar)
        {
            coyoteTimeCounter = coyoteTime;
        }

        if (playerSwitch.isActive)
        {
            float inputHorizontal = -Input.GetAxis("Horizontal");
            // Aplica las fuerzas invertidas al Rigidbody2D del segundo personaje
            rb.velocity = new Vector2(inputHorizontal * velocidad, rb.velocity.y);
        }
        else
        {
            float inputHorizontal = Input.GetAxis("Horizontal");
            // Aplica las fuerzas invertidas al Rigidbody2D del segundo personaje
            rb.velocity = new Vector2(inputHorizontal * velocidad, rb.velocity.y);
        }

        


        // Detectar el salto invertido
        if (Input.GetKeyDown(KeyCode.Space) && coyoteTimeCounter > 0 || Input.GetKeyDown(KeyCode.Joystick1Button0) && coyoteTimeCounter > 0)
        {
            InvertedJump();
        }
        coyoteTimeCounter -= Time.deltaTime;

        Giro();
        CorrerAnim();
        SaltoAnim();
    }

    public void SaltoAnim()
    {
        if (checkGround.puedeSaltar == false)
        {
            anim.SetBool("isJump", true);

        }

        else
        {
            anim.SetBool("isJump", false);



        }
    }

    public void CorrerAnim()
    {
        if (rb.velocity.x != 0)
        {
            
            anim.SetBool("isRun", true);
        }
        else
        {
            anim.SetBool("isRun", false);

        }
    }

    private void InvertedJump()
    {

        if (checkGround.puedeSaltar)
        {
            if (gravity.isGravityReversed)
            {
                FindObjectOfType<AudioManager>().Play("Jump");
                lastJumpPoint = transform.position;

                rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);

            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Jump");
                rb.velocity = new Vector2(rb.velocity.x, -fuerzaSalto);
                lastJumpPoint = transform.position;




            }


        }
    }


    public void Giro()
    {

        if (gravity.isGravityReversed)
        {

            if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if (rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(1, 1, 1);

            }
        }
        else
        {

            if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);

            }
        }
    }

    
}
