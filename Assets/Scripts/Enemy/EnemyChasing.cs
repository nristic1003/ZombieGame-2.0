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

        checkTags();


        if(Vector2.Distance(playerPosition.position , transform.position) > distance && canChase)
        {
            if(playerPosition.position.x < transform.position.x)
                 transform.localScale = new Vector3(-1 , 1, 0);
            else
                transform.localScale = new Vector3(1, 1, 0);
            anim.SetBool("zombieWalk" , true);
            anim.SetBool("zombieAttack", false);
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(playerPosition.position.x, transform.position.y), speed * Time.deltaTime);

        }
        else
        {
            if(timeBetweenAttack <= 0)
            {
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemies.Length; i++)
                    enemies[i].GetComponent<Player>().TakeDamage(4);
                anim.SetBool("zombieWalk", false);
                anim.SetBool("zombieAttack", true);
                timeBetweenAttack = startTime;
            }
            else {
                timeBetweenAttack -= Time.deltaTime;
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
