using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject barrel;
    public static bool barrelMode = false;
    void Start()
    {
     
    }


    IEnumerator SpawnBarrel()
    {
        float range = Random.Range(2, 4);
        yield return new WaitForSeconds(range);
        Instantiate(barrel, transform.position, Quaternion.identity);
        StartCoroutine("SpawnBarrel");
    }


    public void StartBarrel()
    {
        if (!BarrelControl.barrelControl)
        {
            StartCoroutine("SpawnBarrel");
            BarrelControl.barrelControl = true;
        }       
    }

    public void StopBarrels()
    {
        if (!BarrelControl.barrelControl)
        {
            StopCoroutine("SpawnBarrel");
            BarrelControl.barrelControl = false;
        }
       
    }

  
}
