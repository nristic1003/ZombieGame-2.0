using System;
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

    public GameObject ladderButton;

    public Animator anim;

    public GameObject climbButtons, weaponsButtons;

    private bool up, down;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       /* vertical = Input.GetAxisRaw("Vertical");*/
        if(isLadder && Mathf.Abs(vertical) > 0)
        {
            isClimbing = true;
        }
    }

    public void setDirrection(bool v)
    {
        up = v;
        down = !v;
    }

    public void clearMovong()
    {
        up = down = false;
    }

    public void startClimbing()
    {
        isClimbing = true;
        anim.speed = 1f;
        anim.SetBool("goingUp", true);
        climbButtons.SetActive(true);
        weaponsButtons.SetActive(false);

    }

    private void FixedUpdate()
    {
        if(isClimbing)
        {
          
            if (up || down)
            {
                if (up) vertical = 1f;
                else vertical = -1f;
                anim.speed = 1f;
                anim.SetBool("goingUp", true);
               

            }
            else
            {    
                anim.speed = 0f;
                vertical = 0f;
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
            ladderButton.SetActive(true);

        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
            ladderButton.SetActive(false);
            climbButtons.SetActive(false);
            weaponsButtons.SetActive(true);
            vertical = 0f;
            clearMovong();
        }
    }
}
