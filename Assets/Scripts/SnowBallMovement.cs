using EZCameraShake;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnowBallMovement : MonoBehaviour
{

    public float speed = 2f;
    public float rollingSpeed = 1f;
    public Rigidbody2D myBody;
    public float health = 15f;
    private float timeToGetAHealth = 1f;
    public GameObject effect;
    // Start is called before the first frame update
    void Start()
    {
        myBody = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if(timeToGetAHealth <=0)
        {
            health += 5f;
            timeToGetAHealth = 1f;
        }
        else
        {
            timeToGetAHealth -= Time.deltaTime;
        }

        transform.Rotate(0, 0, 360 * speed * Time.deltaTime);
        transform.localScale = new Vector3(transform.localScale.x + 0.0001f, transform.localScale.y + 0.0001f, 1);
        
    }

    private void FixedUpdate()
    {
        myBody.AddForce(new Vector2(-1 * rollingSpeed, 0));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Bullet")
        {
            health -= 5;
            if (health <= 0)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                CameraShaker.Instance.ShakeOnce(4f, 4f, 0.1f, 1f);
                Destroy(gameObject);

            }
            Destroy(collision.gameObject);
               
        }
    }

}
