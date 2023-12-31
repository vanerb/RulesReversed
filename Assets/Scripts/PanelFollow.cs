using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelFollow : MonoBehaviour
{
    public Transform jugador1;
    public Transform jugador2;
    public float velocidad;
    public PlayerSwitch playerSwitch;

    public float time;

    public Text cronometertxt;
    public GameObject crCanvas;
    // Start is called before the first frame update
    void Start()
    {
        time = 3;
        crCanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSwitch.isActive)
        {
            if (jugador1 != null)
            {
                Vector3 direccion = jugador1.position - transform.position;
                direccion.Normalize();
                transform.position += direccion * velocidad * Time.deltaTime;
            }
        }
        else
        {
            if (jugador2 != null)
            {
                Vector3 direccion = jugador2.position - transform.position;
                direccion.Normalize();
                transform.position += direccion * velocidad * Time.deltaTime;
            }
        }
        cronometertxt.text = System.Math.Round(time, 1).ToString() + " s";


    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") || collision.CompareTag("Player2"))
        {
            crCanvas.SetActive(true);
            time -= Time.deltaTime;
           
            if (time <= 0)
            {
                collision.gameObject.GetComponent<LifePlayer>().Hit(200);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") || collision.CompareTag("Player2"))
        {
            crCanvas.SetActive(false);
            time = 3;
           
        }
    }
}
