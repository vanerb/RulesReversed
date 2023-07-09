using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelPass : MonoBehaviour
{
    private bool jugador1EnColision;
    private bool jugador2EnColision;

    private void Start()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugador1EnColision = true;
        }
        else if (other.CompareTag("Player2"))
        {
            jugador2EnColision = true;
        }

        if (jugador1EnColision && jugador2EnColision)
        {
            Debug.Log("NUEVA ESCENA");
            Scene currentScene = SceneManager.GetActiveScene();
            if (currentScene.buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
            {
                
                SceneManager.LoadScene(currentScene.buildIndex + 1);
            }
            else
            {
                SceneManager.LoadScene("Menu");
            }
            
           
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            jugador1EnColision = false;
        }
        else if (other.CompareTag("Player2"))
        {
            jugador2EnColision = false;
        }
    }
}
