using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifePlayer : MonoBehaviour
{
    public float maxHealth;
    public float health;

    // Start is called before the first frame update
    void Start()
    {

        health = maxHealth;

      
    }

    // Update is called once per frame
    void Update()
    {
       if(health <= 0)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(currentScene.buildIndex);
        }
    }

    
    public void Hit(float dano)
    {
        health -= dano;
        
    }

    public void SumarVida(float vida)
    {
        health += vida;
    }
}
