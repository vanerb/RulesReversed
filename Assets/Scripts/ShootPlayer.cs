using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootPlayer : MonoBehaviour
{
    public Transform attackPoint;
    public GameObject projectilePrefab;
    public LayerMask enemyLayers;
    public int attackDamage = 10;
    public Animator anim;
    public float attackInterval = 1f; // Intervalo de 1 segundo
    private float lastAttackTime; // Tiempo del último ataque
    private Rigidbody2D rb;
    private int ndisparos = 6;
    public GameObject[] balas;
    private bool isRecargando = false;

    public bool isDisparando = false;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!GetComponent<AttackPlayer>().isAttack)
        {
            if (rb.velocity.x == 0)
            {
                if (ndisparos > 0 && isRecargando == false)
                {
                    // Verificar si ha pasado el tiempo suficiente desde el último ataque
                    if (Time.time >= lastAttackTime + attackInterval)
                    {
                        if (Input.GetKeyDown(KeyCode.Mouse1))
                        {
                            isDisparando = true;
                            // StartCoroutine(Dispara());
                            anim.SetTrigger("Shoot");
                            lastAttackTime = Time.time; // Actualizar el tiempo del último ataque
                        }
                    }
                }

            }
        }
       

        if (Input.GetKeyDown(KeyCode.R) && ndisparos<7)
        {
            isRecargando = true;
            StartCoroutine(recarga());
        }
       
    }


    IEnumerator recarga()
    {
        int numeroRestante = 6 - ndisparos;
        for(int i= 0;i < numeroRestante; i++)
        {

            yield return new WaitForSeconds(0.5f);
            ndisparos++;

            balas[ndisparos-1].SetActive(true);
        }
        isRecargando = false;

    }
   

    void Shoot()
    {
        ndisparos--;
        balas[ndisparos].SetActive(false);
        // Calcular la dirección del disparo basándose en la escala del personaje
        Vector2 direction = transform.right;
        if (transform.localScale.x < 0)
        {
            direction = -direction;
        }

        // Instanciar un proyectil en la posición del ataque
        GameObject projectile = Instantiate(projectilePrefab, attackPoint.position, Quaternion.identity);

        // Obtener el componente del proyectil (asumiendo que tiene un script de proyectil)
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            // Configurar el daño del proyectil
            projectileScript.SetDamage(attackDamage);

            // Establecer la dirección del proyectil
            projectileScript.SetDirection(direction);
        }
        StartCoroutine(DejarDisparar());
        
    }

    IEnumerator DejarDisparar()
    {
        yield return new WaitForSeconds(0.2f);
        isDisparando = false;
    }
    
}
