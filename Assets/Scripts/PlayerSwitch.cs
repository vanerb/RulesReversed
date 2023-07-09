using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
  

    public bool isActive = false;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            SwitchPlayer(); 
        }
    }

    private void SwitchPlayer()
    {
        if (isActive)
        {
            isActive = false;
        }
        else
        {
            isActive = true;
        }
    }
}
