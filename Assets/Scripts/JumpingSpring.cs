using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingSpring : MonoBehaviour
{

    public Animator anim;
    public float jumpForce = 22f;
    public Vector3 springUp; 
    // Start is called before the first frame update
    void Awake()
    {
      
        springUp = transform.up;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player")
        {
           // anim.SetBool("goingUp" , true);

            collision.gameObject.GetComponent<PlayerMovement>().bouncePlayer(jumpForce);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            anim.SetBool("throw", false);
        }
    }
}
