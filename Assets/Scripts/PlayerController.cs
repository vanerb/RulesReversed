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

    public PlayerSwitch playerSwitch;

    public Vector2 lastJumpPoint;

    public float coyoteTime = 0.1f; // Tiempo en segundos que dura el Coyote Time.
    private float coyoteTimeCounter; // Contador interno para el tiempo restante.

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        lastJumpPoint = transform.position;
     

    }

    void Update()
    {


        if (playerSwitch.isActive)
        {
            float inputHorizontal = Input.GetAxis("Horizontal");
            // Aplica las fuerzas invertidas al Rigidbody2D del segundo personaje
            rb.velocity = new Vector2(inputHorizontal * velocidad, rb.velocity.y);
        }
        else
        {
            float inputHorizontal = -Input.GetAxis("Horizontal");
            // Aplica las fuerzas invertidas al Rigidbody2D del segundo personaje
            rb.velocity = new Vector2(inputHorizontal * velocidad, rb.velocity.y);
        }

        if (checkGround.puedeSaltar)
        {
            coyoteTimeCounter = coyoteTime;
        }

        if (Input.GetKeyDown(KeyCode.Space) && coyoteTimeCounter > 0 || Input.GetKeyDown(KeyCode.Joystick1Button0) && coyoteTimeCounter > 0)
        {
           
            if (checkGround.puedeSaltar)
            {
                
                Salto();

                    
            }
           

        }
        coyoteTimeCounter -= Time.deltaTime;


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
                lastJumpPoint = transform.position;
            }
            else
            {
                FindObjectOfType<AudioManager>().Play("Jump");
                rb.velocity = new Vector2(rb.velocity.x, -fuerzaSalto);
                lastJumpPoint = transform.position;



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
