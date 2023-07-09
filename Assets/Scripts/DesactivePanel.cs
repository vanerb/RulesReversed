using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesactivePanel : MonoBehaviour
{
    public GameObject panel;
    public KeyCode key;
    private bool isActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && isActive == false || collision.CompareTag("Player2") && isActive == false)
        {
            panel.SetActive(true);
            isActive = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Player2"))
        {
            panel.SetActive(false);
            isActive = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key))
        {
            panel.SetActive(false);
        }
    }
}
