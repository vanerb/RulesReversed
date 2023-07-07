using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifePlayer : MonoBehaviour
{
    public Slider slider;
    public float maxHealth;
    public float health;

    // Start is called before the first frame update
    void Start()
    {

        health = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = health;

      
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;

        
      
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
