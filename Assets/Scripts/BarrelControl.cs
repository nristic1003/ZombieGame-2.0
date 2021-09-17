using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelControl : MonoBehaviour
{
    public static bool barrelControl = false;


    private void Start()
    {
        barrelControl = false;
    }

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.tag == "Player")
        {
            if(!barrelControl)
                GameObject.Find("BarrelSpawnerLocation").GetComponent<BarrelSpawner>().StartBarrel();
           else
                GameObject.Find("BarrelSpawnerLocation").GetComponent<BarrelSpawner>().StopBarrels();

        }

    }
}
