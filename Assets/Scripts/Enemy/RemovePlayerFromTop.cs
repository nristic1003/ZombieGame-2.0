using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemovePlayerFromTop : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
            GameObject p = GameObject.Find(collision.name);
            if(transform.parent.position.y < p.transform.position.y)
            {
                Vector2 v = new Vector2(p.transform.localScale.x * 400f, 0);
                GameObject.Find(collision.name).GetComponent<Rigidbody2D>().AddForce(v);
               
            }

          
        }
    }
}
