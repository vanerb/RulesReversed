using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed = 10f; // Velocidad del proyectil
    public int damage = 10; // Daño del proyectil

    private Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Destroy(gameObject, 3f);
    }

    public void SetDirection(Vector2 direction)
    {
        rb.velocity = direction.normalized * speed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si colisionó con un enemigo
        if (collision.CompareTag("Enemy"))
        {
            // Obtener el componente EnemyHealth del enemigo y aplicar daño
            //EnemyHealth enemyHealth = collision.GetComponent<EnemyHealth>();
            //if (enemyHealth != null)
            //{
            //    enemyHealth.TakeDamage(damage);
            //}

            // Destruir el proyectil después de colisionar con un enemigo
            Destroy(gameObject);
        }
    }

    public void SetDamage(int newDamage)
    {
        damage = newDamage;
    }
}
