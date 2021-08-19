using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    // Start is called before the first frame update

    public Animator anim;
    private Rigidbody2D myBody;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    float verticalMove = 0f;
    bool jump = false;
    bool canGoUp = false;
    public float climbingSpeed = 1.1f ;


    public LayerMask whatIsLadder;
    public float distance;
    private bool isClimbing;
    private bool left, right;

    private bool jumpRequest = false;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (left)
            horizontalMove = -1f * runSpeed;
        else if (right) horizontalMove = 1f * runSpeed;
        else horizontalMove = 0f * runSpeed;
        // verticalMove =Input.GetAxisRaw("Vertical") * climbingSpeed;
        anim.SetFloat("speed", Mathf.Abs(horizontalMove));
        if(jumpRequest)
        {
            jump = true;
            anim.SetBool("isJumping", true);
        }

    }

    public void setDirrection(bool v)
    {
        left = v;
        right = !v;
    }

    public void clearMovong()
    {
        left = right = false;
    }


    public void OnLanding()
    {
      //  anim.SetBool("isJumping", false);
    } 

    private void FixedUpdate()
    {
        //Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        jumpRequest = false;

    }

    public void bouncePlayer(float jumpForce)
    {

        myBody.velocity = new Vector2(0, jumpForce);
        anim.SetBool("isJumping", true);
        anim.SetBool("goingUp", false);
        

    }

    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "Ground")
        {
            anim.SetBool("isJumping", false);
        }


        if(target.gameObject.CompareTag("Platform"))
        {
            anim.SetBool("isJumping", false);
            this.transform.parent = target.transform;
        }

    }

    public void checkJumping()
    {
        jumpRequest = true;
    }

    private void OnCollisionExit2D(Collision2D target)
    {
        if (target.gameObject.CompareTag("Platform"))
        {
            anim.SetBool("isJumping", true);
            this.transform.parent = null;
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
        if (collision.tag == "newBullets")
        {
            GetComponent<PlayerAttack>().setBullets(10);
            Destroy(collision.gameObject);
        }

        if(collision.tag =="Ladder")
        {
            canGoUp = true;
        }

        if(collision.tag=="FinishTag")
        {
            GameController.gameManager.FinishTheGame();
        }
    }
/*    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ladder")
        {
            anim.SetBool("Up", false);
        }
    }*/
}
