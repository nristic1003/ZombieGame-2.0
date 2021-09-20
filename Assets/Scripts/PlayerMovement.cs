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

    public void clearJumping()
    {
        jumpRequest = false;
    }

    private bool left, right;

    private bool jumpRequest = false;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // funkcija Update se poziva uvek pre, i dosta česće u odnosu na funckiju FixedUpdate. Pored toga se poziva za svaki frejm,
        // pa se ovde koristi da pripremi parametre potrebne funckiji FixedUpdate u kojoj će se izvršiti potrebne radnje 
        if (left)    //left ukoliko je igač priticnuo dugme za kretannje levo
            horizontalMove = -1f * runSpeed; //brzina koja će se primeniti na igrača
        else if (right)   //right ukoliko je igač priticnuo dugme za kretannje desno
            horizontalMove = 1f * runSpeed; //brzina koja će se primeniti na igrača
        else horizontalMove = 0f * runSpeed; //nije pritisnuto dugme -: brzina = 0
        anim.SetFloat("speed", Mathf.Abs(horizontalMove)); //uslov kojim se manipuliše da bi se prešlo u stanje kretanja (Player Walking)
        if(jumpRequest) //provera da li je pritisnuto dugme za skok
        {
            jump = true; //flag da će doći do skoka
            anim.SetBool("isJumping", true); //uslov kojim se manipuliše da bi se desila tranzicija između stanja (Jump)
        }
    }

    private void FixedUpdate()
    {
        //Move our character
        //funkcija FixedUpdate se koristi za rad sa fizikom unutar igre, pa se u ovom konkretnom slučaju koristi za kretanje samog igrača, i skakanje
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump); //poziv funkcije za kretanje karaktera, prvi parametar = kretanje,
                                                                            //drugi parametar = crouch, treci parametar = skok
        jump = false; //resetovanje parametara za skok
        jumpRequest = false; //resetovanje parametra za zahtev skoka
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

    public void checkJumping(bool res)
    {
        jumpRequest = res;
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
