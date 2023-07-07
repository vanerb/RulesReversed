using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayer : MonoBehaviour
{
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    public int attackDamage = 10;
    public Animator anim;

    public float attackInterval = 1f; // Intervalo de 1 segundo
    private float lastAttackTime; // Tiempo del último ataque

    public bool isAttack = false;
   
    void Update()
    {
        if (!GetComponent<ShootPlayer>().isDisparando)
        {
            if (Time.time >= lastAttackTime + attackInterval)
            {
                if (Input.GetKeyDown(KeyCode.Mouse0))
                {
                    isAttack = true;
                    anim.SetTrigger("Attack");
                    lastAttackTime = Time.time;

                }
            }
        }
       
    }

    void Attack()
    {
        
        // Detectar enemigos en el rango de ataque
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        // Aplicar daño a los enemigos
        foreach (Collider2D enemy in hitEnemies)
        {
            //enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }

        StartCoroutine(DejarAtacar());
    }

    IEnumerator DejarAtacar()
    {
        yield return new WaitForSeconds(0.2f);
        isAttack = false;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        // Dibujar un gizmo para representar el rango de ataque en el editor
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
