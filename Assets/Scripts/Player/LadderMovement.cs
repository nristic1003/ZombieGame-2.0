using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    // Start is called before the first frame update



    public Rigidbody2D myBody;
    private bool isLadder;
    private bool isClimbing;
    public float speed = 8f;
    private float vertical;

    public Animator anim;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        if(isLadder && Mathf.Abs(vertical) > 0)
        {
            isClimbing = true;
        }
    }

    private void FixedUpdate()
    {
        if(isClimbing)
        {
            if(vertical ==1 || vertical ==-1)
            {
                anim.speed = 1f;
                anim.SetBool("goingUp", true);
                
            }else
            {
                anim.speed = 0f;
            }
            myBody.gravityScale = 0f;
            myBody.velocity = new Vector2(myBody.velocity.x, vertical * speed);
        }
        else
        {
            anim.speed = 1f;
            anim.SetBool("goingUp", false);
          //  anim.SetBool("goingDown", false);
            myBody.gravityScale = 3f;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
