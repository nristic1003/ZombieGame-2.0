using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCutscene : MonoBehaviour
{
    public static bool cutSceneOn = false;
    public Animator cam;
    

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
           
            cutSceneOn = true;
            cam.SetBool("cutscene1" , true);
            GameObject.Find("VelikaTestera").GetComponent<Animator>().SetBool("fadeIn", true);
            Invoke(nameof(stopCutScene), 3f);
        }
    }

    void stopCutScene()
    {
        GameObject.Find("VelikaTestera").GetComponent<SawRotation>().moveForward = true;
        GameObject.Find("VelikaTestera").GetComponent<Animator>().SetBool("moveRight", true);
        cutSceneOn = false;
        cam.SetBool("cutscene1", false);
        Destroy(gameObject);
    }

}
