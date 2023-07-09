using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float velocidad = 5f; // Velocidad de movimiento del personaje
    public float fuerzaSalto = 5f; // Fuerza de salto del personaje

    public Rigidbody2D rb; // Referencia al componente Rigidbody2D
    [SerializeField] private CheckGround checkGround;

    public Animator anim;

    public BoxCollider2D hitBox;

    public GravityControl gravity;

    public float movimientoHorizontal;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

     

    }

    void Update()
    {


        movimientoHorizontal = Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(movimientoHorizontal * velocidad, rb.velocity.y);

       

        if (Input.GetKeyDown(KeyCode.Space))
        {
           
            if (checkGround.puedeSaltar)
            {
                Salto();

                    
            }
           
        }


        Giro();
        CorrerAnim();
        SaltoAnim();
        
    }


   

    public void Salto()
    {
        if (checkGround.puedeSaltar)
        {
            if (gravity.isGravityReversed)
            {
                FindObjectOfType<AudioManager>().Play("Jump");
                rb.velocity = new Vector2(rb.velocity.x, fuerzaSalto);

            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Jump");
                rb.velocity = new Vector2(rb.velocity.x, -fuerzaSalto);



            }


        }
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

    public void Giro()
    {

        if (gravity.isGravityReversed)
        {

            if (rb.velocity.x < 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else if(rb.velocity.x > 0)
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
            else if(rb.velocity.x > 0)
            {
                transform.localScale = new Vector3(-1, 1, 1);

            }
        }
    }


}
