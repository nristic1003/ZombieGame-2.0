using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChasing : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public CharacterController2D controller;


    public float distance = 3;

    private Transform playerPosition;
    private Animator anim;

   
    //moving left, right
    public Transform rightPos, leftPos;
    public bool canChase;

    //attack
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemy;
    private float timeBetweenAttack;
    public float startTime;


    private void Awake()
    {
        playerPosition = GameObject.FindWithTag("Player").transform;
        anim = GetComponent<Animator>();
    }
    void Update()
    {

        checkTags(); // funkcija za proveru da li može zombi da krene sa kretanjem
        if(Vector2.Distance(playerPosition.position , transform.position) > distance && canChase) //ukoliko je glavni junak dovoljno daleko,
                                                                                                  //i zombi može da juri igrača
        {
            if(playerPosition.position.x < transform.position.x) //promena smera u kojem je okrenut zombi,
                                                                 //uvek je okrenut tako da ide u susret igracu -- kretanje levo (-1)
                 transform.localScale = new Vector3(-1 , 1, 0);
            else
                transform.localScale = new Vector3(1, 1, 0);  //promena smera u kojem je okrenut zombi,
                                                              //uvek je okrenut tako da ide u susret igracu -- kretanje desno (1)
            anim.SetBool("zombieWalk" , true);  //uslov kojim se manipuliše da bi se prešlo u stanje kretanja 
            anim.SetBool("zombieAttack", false);//uslov kojim se manipuliše da bi se završila animacija napada
            transform.position = 
                Vector2.MoveTowards(transform.position, new Vector2(playerPosition.position.x, transform.position.y), speed * Time.deltaTime); 
                //kretanje ka glavnom junaku određenom brzinom
        }
        else
        {
            if(timeBetweenAttack <= 0) // vreme koje mora da protekne da bi zombi ponovo napao
            {
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy); //skup neprjatelja koji se nalaze u crvenom krugu
                for (int i = 0; i < enemies.Length; i++)
                    enemies[i].GetComponent<Player>().TakeDamage(4); //svi neprijatelji koji su se nasli unutar kruga ce izgubiti 4 healtha
                anim.SetBool("zombieWalk", false); //uslov kojim se manipuliše da bi se zavrsila animacija kretanja 
                anim.SetBool("zombieAttack", true);//uslov kojim se manipuliše da bi se prešlo u stanje napada 
                timeBetweenAttack = startTime;
            }
            else {
                timeBetweenAttack -= Time.deltaTime; //smanjivanje vremena koje je proteklo od prethodnog napada
            }
           
        }
           
    }


   void  checkTags()
    {
        bool right = Physics2D.Linecast(transform.position, rightPos.position, 1 << LayerMask.NameToLayer("Ground"));
        bool left = Physics2D.Linecast(transform.position, leftPos.position, 1 << LayerMask.NameToLayer("Ground"));
        if (playerPosition.position.x < transform.position.x)
        {
            if (left) canChase = true;
            else canChase = false;
        }else if(playerPosition.position.x > transform.position.x )
        {
            if (right) canChase = true;
            else canChase = false;
        }
        
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
