using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MetersCount : MonoBehaviour
{
    public PlayerSwitch playerSwitch;
    public GameObject player1;
    public GameObject player2;
    public Text meterstxt;
    public float meterscount;
    // Start is called before the first frame update
    void Start()
    {
        meterscount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerSwitch.isActive)
        {
            if(player1.GetComponent<Rigidbody2D>().velocity.x > 0 || player1.GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                meterscount += Time.deltaTime;
            }
        }
        else
        {
            if (player2.GetComponent<Rigidbody2D>().velocity.x > 0 || player2.GetComponent<Rigidbody2D>().velocity.x < 0)
            {
                meterscount += Time.deltaTime;
            }
        }

        meterstxt.text = System.Math.Round(meterscount, 1).ToString() + " M";
    }
}
