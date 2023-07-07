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

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {

        float inputHorizontal = -jugador.movimientoHorizontal;

        // Aplica las fuerzas invertidas al Rigidbody2D del segundo personaje
        rb.velocity = new Vector2(inputHorizontal * velocidad, rb.velocity.y);


        // Detectar el salto invertido
        if (Input.GetKeyDown(KeyCode.Space))
        {
            InvertedJump();
        }

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

                rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);

            }
            else
            {
                rb.velocity = new Vector2(rb.velocity.x, -fuerzaSalto);



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
