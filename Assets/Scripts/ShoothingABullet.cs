using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoothingABullet : MonoBehaviour
{
    public int speed;
    private Transform player;
    public float dirrection;


    void Awake()
    {

    }

    public void setScale(Vector3 f)
    {
        transform.localScale = f;
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player").transform;

        if (dirrection == 1)
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
            //Debug.Log("Desno");
        }

        else
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            //  Debug.Log("Levo");
        }
 

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            GameObject.Find(collision.gameObject.name).GetComponent<Enemy>().TakeDamage(1);
            Destroy(gameObject);
         
        }

        if (collision.tag == "Player")
        {
            GameObject.Find(collision.gameObject.name).GetComponent<Player>().TakeDamage(10);
            Destroy(gameObject);

        }
        if (collision.tag == "Collector")
        {
            Destroy(gameObject);
        }

    }
}
