using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotation : MonoBehaviour
{


    public float speed = 2f;
    public bool moveForward = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
     
        if (moveForward)
        {
          
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            if(gameObject.tag=="malaTestera")
            {
                GameObject.Find("Player").GetComponent<Player>().TakeDamage(15);
            }
            if(gameObject.name=="VelikaTestera")
            {
                GameObject.Find("Player").GetComponent<Player>().TakeDamage(100);
            }
        
        }
    }
}
