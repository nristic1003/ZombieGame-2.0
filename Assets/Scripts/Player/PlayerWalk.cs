using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalk : MonoBehaviour
{

    private Rigidbody2D myBody;
    private Animator anim;

    [SerializeField]
    private float jumpForce = 10f, fallMultiplier = 3f;
    private float lowJumpMultiplier = 2.5f;


    private float speed = 30f;

    private bool canJump = false;

    public bool canGoUp = false;

    public bool grounded = true;

    public bool canAttack = false;

    private bool left = false, right = false;
    private bool jumpingRequest;
    private float horizontalMove;
    private bool moveRequest;

    public void setDirrection(bool v)
    {
        left = v;
        right = !v;
    }

    public void clearMovong()
    {
        left = right = false;
    }


    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //checkGoUp();
       
       if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpingRequest = true;
        }
         horizontalMove = Input.GetAxisRaw("Horizontal");
        if(horizontalMove !=0)
        {
            checkMoving(horizontalMove);
        }else
        {
            anim.SetBool("walk", false);
        }
       



    }



    private void FixedUpdate()
    {
        if(jumpingRequest)
        {
            checkJumping();
            jumpingRequest = false;
        }
       /* if(moveRequest)
        {
            checkMoving(horizontalMove);
            moveRequest = false;

        }*/

    }

    void checkMoving(float l)
    {
        //float l = Input.GetAxisRaw("Horizontal");

        Vector2 temp = transform.position;

       // if (left || right)
        if(l ==1 || l==-1)
        {
 /*           if (Input.GetKeyDown(KeyCode.Space) && canJump)
                anim.SetBool("jump", true);
            else*/
                anim.SetBool("walk", true);
            // l = right ? l = 1 : l = -1;
            temp.x += speed * Time.deltaTime * l;
            transform.localScale = new Vector3(l, 1, 0);

        }

        transform.position = temp;
    }

    public void checkJumping()
    {

        if (myBody.velocity.y < 0)
        {
            myBody.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }else if(myBody.velocity.y > 0  && !Input.GetKeyDown(KeyCode.Space))
        {
            myBody.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            Debug.Log("da");
        }

        if (canJump)
        {
            anim.SetBool("jump", true);
            myBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canJump = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ground")
        {
            canJump = true;
            grounded = true;
            anim.SetBool("jump", false);
           
        }
    }
    private void OnCollisionExit2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ground")
        {
            grounded = false;
          
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Spikes")
        {
            myBody.AddForce(new Vector2(3.0f * transform.localScale.x, 8f), ForceMode2D.Impulse);
        }

        if (collision.tag == "coin")
        {
            GameController.gameManager.increaseCoins(1);
            GetComponent<PlayerAttack>().setCoinClip();
            Destroy(collision.gameObject);
        }
        if(collision.tag == "newBullets")
        {
            GetComponent<PlayerAttack>().setBullets(10);
            Destroy(collision.gameObject);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            anim.SetBool("Up", false);
        }
    }

}
