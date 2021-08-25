using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    

    private Animator anim;
    public Transform attackPos;
    public float attackRange;
    public LayerMask whatIsEnemy;

    public ShoothingABullet bullet;

    private float timeBetweenAttack = 1.5f;
    public float startTime;

    private AudioSource source;
    public AudioClip shoothing, collectingCoin;

    private bool canShoot = true;
    [SerializeField]
    private int numOfBullets = 10;

    private bool gun = false, knife = false;

    void Awake()
    {
        source = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        
    }

    private void Start()
    {
        GameController.gameManager.setNUmOfBullets(numOfBullets);
    }

    // Update is called once per frame
    void Update()
    {

        if(timeBetweenAttack <=0)
        {
            if (knife)
            {
                anim.SetBool("attack", true);
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemy);
                for (int i = 0; i < enemies.Length; i++)
                    enemies[i].GetComponent<Enemy>().TakeDamage(2);


            }else if (gun && numOfBullets > 0)
            {
                numOfBullets--;
                GameController.gameManager.setNUmOfBullets(numOfBullets);
                anim.SetBool("shoot", true);
                source.clip = shoothing;
                source.Play();
                if(transform.localScale.x ==1)
                {
                    ShoothingABullet clone = Instantiate(bullet, new Vector3(transform.position.x + 1f, transform.position.y - 0.35f, 0), Quaternion.identity);
                    clone.dirrection = transform.localScale.x;
                    clone.setScale(transform.localScale);
                }
                else
                {
                    ShoothingABullet clone = Instantiate(bullet, new Vector3(transform.position.x - 1f, transform.position.y - 0.35f, 0), Quaternion.identity);
                    clone.dirrection = transform.localScale.x;
                    clone.setScale(transform.localScale);
                }

                    
                
            }
            else
            {
                anim.SetBool("attack", false);
                anim.SetBool("shoot" , false);
            }
            timeBetweenAttack = startTime;
        }
      
        else
        {
                timeBetweenAttack -= Time.deltaTime;
               

            }
       
    }

    public void setAttack(bool at)
    {
        gun = at;
        knife = !at;
    }

    public void clearAttack()
    {
        gun = knife = false;
    }

    public void setBullets(int b)
    {
        numOfBullets += b;
        GameController.gameManager.setNUmOfBullets(numOfBullets);
    }

    public void setCoinClip()
    {
        source.clip = collectingCoin;
        source.Play();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
