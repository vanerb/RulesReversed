using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tramp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Player2"))
        {
            FindObjectOfType<AudioManager>().Play("Muerte");
            StartCoroutine(Muerte(collision));
        }
    }

    IEnumerator Muerte(Collider2D collision)
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(collision.gameObject);
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.buildIndex);
    }
}
