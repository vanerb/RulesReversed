using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tramp : MonoBehaviour
{
    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Player2"))
        {
            FindObjectOfType<AudioManager>().Play("Muerte");
           
            StartCoroutine(Muerte(collision));
        }

    }
    IEnumerator Muerte(Collision2D collision)
    {
        yield return new WaitForSeconds(0.1f);
        if (collision.gameObject.GetComponent<EscudoProtector>().isActive == false)
        {
            collision.gameObject.GetComponent<LifePlayer>().Hit(200);
        }
        else
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                collision.gameObject.transform.position = collision.gameObject.GetComponent<PlayerController>().lastJumpPoint;
            }
            if (collision.gameObject.CompareTag("Player2"))
            {
                collision.gameObject.transform.position = collision.gameObject.GetComponent<SecondCharacter>().lastJumpPoint;

            }
        }
    }
}