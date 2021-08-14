using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{

    private PlayerWalk p;

    private void Awake()
    {
        p = GameObject.Find("Player").GetComponent<PlayerWalk>();
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            p.canGoUp = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            p.canGoUp = false;
        }
    }
}
