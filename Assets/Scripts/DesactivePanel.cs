using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivePanel : MonoBehaviour
{
    public GameObject panel;
    public KeyCode key;
    public KeyCode keyJoystick;
    public static bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0f;
        isActive = false;
    }
   

    // Update is called once per frame
    void Update()
    {

      

        if (Input.GetKeyDown(key) || Input.GetKeyDown(keyJoystick))
        {
            Time.timeScale = 1f;
            panel.SetActive(false);
            isActive = true;
        }
    }
}
