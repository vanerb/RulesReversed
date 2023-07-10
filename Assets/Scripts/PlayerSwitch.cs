using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSwitch : MonoBehaviour
{
  

    public bool isActive = false;
    public GameObject arrowicon1;
    public GameObject arrowicon2;
    private void Start()
    {
        arrowicon1.SetActive(true);
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
            arrowicon1.SetActive(true);
            arrowicon2.SetActive(false);

        }
        else
        {
            isActive = true;
            arrowicon2.SetActive(true);
            arrowicon1.SetActive(false);
        }
    }
}
